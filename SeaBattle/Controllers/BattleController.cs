using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SeaBattle.Data;
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
        private readonly Game _game;

        public BattleController(Game game,
                                IStatisticsService statisticsService,
                                IBattleService battleService,
                                ICreationService creationService,
                                ICoordinatesParser coordinatesParser,
                                IGameLifetimeService gameLifetimeService)
        {
            _game = game;
            _statisticsService = statisticsService;
            _battleService = battleService;
            _creationService = creationService;
            _coordinatesParser = coordinatesParser;
            _gameLifetimeService = gameLifetimeService;
        }

        [Route("create-matrix")]
        [HttpPost]
        public ActionResult CreateMatrix(MatrixSize matrixSize)
        {
            if (!_gameLifetimeService.CheckRequiredStateWithGameState(GameState.NotStarted))
                return BadRequest($"Not allowed in current game state: {_game.State}. Required state: {GameState.NotStarted}");
            if (matrixSize == null || matrixSize.Range <= 0)
                return BadRequest();
            _creationService.CreateMatrix(matrixSize.Range);
            _gameLifetimeService.MoveNextState();
            return Ok();
        }

        [Route("ship")]
        [HttpPost]
        public ActionResult CreateShips(ShipModel shipModel)
        {
            if (!_gameLifetimeService.CheckRequiredStateWithGameState(GameState.MatrixCreated))
                return BadRequest($"Not allowed in current game state: {_game.State}. Required state: {GameState.MatrixCreated}");

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

            _gameLifetimeService.MoveNextState();
            return Ok();
        }

        [Route("shot")]
        [HttpPost]
        public ActionResult<ShotResult> TakeShot(ShotModel shotModel)
        {
            if (!_gameLifetimeService.CheckRequiredStateWithGameState(GameState.ShipsCreated))
                return BadRequest($"Not allowed in current game state: {_game.State}. Required state: {GameState.ShipsCreated}");

            if (shotModel == null)
                return BadRequest();

            var coords = _coordinatesParser.ParseCoords(shotModel.Coordinates);
            _statisticsService.IncrementShotsCount();

            _gameLifetimeService.MoveNextState();
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