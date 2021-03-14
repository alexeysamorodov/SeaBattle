using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SeaBattle.Data;
using SeaBattle.Services;

namespace SeaBattle.Filters
{
    public class ManageGameStateFilter : IActionFilter
    {
        private readonly IGameLifetimeService _gameLifetimeService;
        private readonly GameState _requiredState;
        private readonly Game _game;

        public ManageGameStateFilter(IGameLifetimeService gameLifetimeService,
                                     GameState requiredState,
                                     Game game)
        {
            _gameLifetimeService = gameLifetimeService;
            _requiredState = requiredState;
            _game = game;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!_gameLifetimeService.CheckRequiredStateWithGameState(_requiredState))
            {
                context.Result = new BadRequestObjectResult(
                    $"Not allowed in current game state: {_gameLifetimeService.GetGameState()}. Required state: {_requiredState}");
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.HttpContext.Response.StatusCode != 200)
                return;
            var currentState = _gameLifetimeService.GetGameState();
            if (currentState < GameState.ShipsCreated)
                _gameLifetimeService.MoveNextState();
            else if (currentState == GameState.ShipsCreated && _game.AreAllShipsDestroyed)
                _gameLifetimeService.FinishGame();
        }
    }
}
