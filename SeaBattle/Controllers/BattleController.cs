using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SeaBattle.Data;
using SeaBattle.Filters;
using SeaBattle.Helpers;
using SeaBattle.Models;
using SeaBattle.Services;

namespace SeaBattle.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BattleController : ControllerBase
    {
        private readonly IStatisticsService _statisticsService;
        private readonly IBattleService _battleService;
        private readonly ICreationService _creationService;
        private readonly ICoordinatesParser _coordinatesParser;
        private readonly IGameLifetimeService _gameLifetimeService;

        public BattleController(IStatisticsService statisticsService,
                                IBattleService battleService,
                                ICreationService creationService,
                                ICoordinatesParser coordinatesParser,
                                IGameLifetimeService gameLifetimeService)
        {
            _statisticsService = statisticsService;
            _battleService = battleService;
            _creationService = creationService;
            _coordinatesParser = coordinatesParser;
            _gameLifetimeService = gameLifetimeService;
        }

        [Route("create-matrix")]
        [HttpPost]
        [TypeFilter(typeof(ManageGameStateFilter), Arguments = new object[] { GameState.NotStarted })]
        public ActionResult CreateMatrix(MatrixSize matrixSize)
        {
            if (matrixSize == null || matrixSize.Range <= 0)
                return BadRequest();
            _creationService.CreateMatrix(matrixSize.Range);
            return Ok();
        }

        [Route("ship")]
        [HttpPost]
        [TypeFilter(typeof(ManageGameStateFilter), Arguments = new object[] { GameState.MatrixCreated })]
        public ActionResult CreateShips(ShipModel shipModel)
        {
            if (shipModel == null || string.IsNullOrEmpty(shipModel.Coordinates))
                return BadRequest();

            var shipsCoords = shipModel.Coordinates
                                                       .Split(',')
                                                       .Select(s => s.Trim());
            foreach (var shipCoords in shipsCoords)
            {
                var beginEndCoords = shipCoords.Split();
                var begin = _coordinatesParser.ParseCoords(beginEndCoords[0]);
                var end = _coordinatesParser.ParseCoords(beginEndCoords[1]);
                _creationService.CreateShip(begin, end);
            }

            return Ok();
        }

        [Route("shot")]
        [HttpPost]
        [TypeFilter(typeof(ManageGameStateFilter), Arguments = new object[] { GameState.ShipsCreated })]
        public ActionResult<ShotResult> TakeShot(ShotModel shotModel)
        {
            if (shotModel == null)
                return BadRequest();

            var coords = _coordinatesParser.ParseCoords(shotModel.Coordinates);
            _statisticsService.IncrementShotsCount();
            return _battleService.TakeShot(coords);
        }

        [Route("clear")]
        [HttpPost]
        public void ClearBattle()
        {
            _gameLifetimeService.ClearGame();
            _statisticsService.ClearStatistics();
        }

        [Route("state")]
        [HttpGet]
        public BattleStatistics GetStatistics()
        {
            return _statisticsService.GetBattleStatistics();
        }
    }
}