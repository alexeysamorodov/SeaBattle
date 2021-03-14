using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SeaBattle.Data;

namespace SeaBattle.Filters
{
    public class CheckGameStateFilter : IActionFilter
    {
        private readonly Game _game;
        private readonly GameState _requiredState;

        public CheckGameStateFilter(Game game, GameState requiredState)
        {
            _game = game;
            _requiredState = requiredState;
        }

        public void OnActionExecuted(ActionExecutedContext context) { }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (_game.State != _requiredState)
            {
                context.Result = new BadRequestObjectResult(
                    $"Not allowed in current game state: {_game.State}. Required state: {_requiredState}");
            }
        }
    }
}
