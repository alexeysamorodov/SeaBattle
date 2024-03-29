﻿using Microsoft.AspNetCore.Mvc;
using SeaBattle.Data;
using SeaBattle.Exceptions;
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
        private readonly Game _game;

        public BattleController(IStatisticsService statisticsService,
                                IBattleService battleService,
                                ICreationService creationService,
                                ICoordinatesParser coordinatesParser,
                                IGameLifetimeService gameLifetimeService,
                                Game game)
        {
            _statisticsService = statisticsService;
            _battleService = battleService;
            _creationService = creationService;
            _coordinatesParser = coordinatesParser;
            _gameLifetimeService = gameLifetimeService;
            _game = game;
        }

        [Route("create-matrix")]
        [HttpPost]
        [TypeFilter(typeof(ManageGameStateFilter), Arguments = new object[] { new[]{GameState.NotStarted, GameState.Finished}})]
        public ActionResult CreateMatrix(MatrixSize matrixSize)
        {
            if (matrixSize == null || matrixSize.Range <= 0 || matrixSize.Range > 26)
                return BadRequest("Invalid matrix size. Required size: 0 < matrixSize <= 26");
            if (_gameLifetimeService.GetGameState() == GameState.Finished)
                _gameLifetimeService.ClearGame();
            _creationService.CreateMatrix(matrixSize.Range);
            return Ok();
        }

        [Route("ship")]
        [HttpPost]
        [TypeFilter(typeof(ManageGameStateFilter), Arguments = new object[] {new[] {GameState.MatrixCreated}})]
        public ActionResult CreateShips(ShipModel shipModel)
        {
            if (shipModel == null || string.IsNullOrEmpty(shipModel.Coordinates))
                return BadRequest();
            try
            {
                var shipsCoords = _coordinatesParser.ParseShipsCoordinates(shipModel.Coordinates,
                                                                                         _game.Matrix.Size);
                _creationService.CreateShips(shipsCoords);
            }
            catch (BadCoordinatesException e)
            {
                _game.ResetMatrixWithShips();
                return BadRequest(e.ToString());
            }
            return Ok();
        }

        [Route("shot")]
        [HttpPost]
        [TypeFilter(typeof(ManageGameStateFilter), Arguments = new object[] {new[] {GameState.ShipsCreated}})]
        public ActionResult<ShotResult> TakeShot(ShotModel shotModel)
        {
            if (shotModel == null)
                return BadRequest();
            Coordinates coords;
            try
            {
                coords = _coordinatesParser.ParseCellCoords(shotModel.Coordinates, _game.Matrix.Size);
            }
            catch (BadCoordinatesException e)
            {
                return BadRequest(e.ToString());
            }
            if (_battleService.CheckCellIsAlive(coords))
                return BadRequest($"Shot at coordinates: {coords.StringRepresentation} was taken earlier.");
            _statisticsService.IncrementShotsCount();
            return _battleService.TakeShot(coords);
        }

        [Route("clear")]
        [HttpPost]
        public void ClearBattle()
        {
            _gameLifetimeService.ClearGame();
        }

        [Route("state")]
        [HttpGet]
        public BattleStatistics GetStatistics()
        {
            return _statisticsService.GetBattleStatistics();
        }
    }
}