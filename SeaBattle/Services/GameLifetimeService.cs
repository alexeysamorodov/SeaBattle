using SeaBattle.Data;

namespace SeaBattle.Services
{
    public class GameLifetimeService : IGameLifetimeService
    {
        private readonly Game _game;

        public GameLifetimeService(Game game)
        {
            _game = game;
        }

        public bool CheckRequiredStateWithGameState(GameState requiredState) => _game.State == requiredState;

        public GameState GetGameState() => _game.State;

        public void MoveNextState()
        {
            if (_game.State < GameState.Finished)
                _game.State++;
        }

        public void ClearGame()
        {
            _game.Clear();
        }

        public void FinishGame()
        {
            _game.State = GameState.Finished;
        }
    }
}
