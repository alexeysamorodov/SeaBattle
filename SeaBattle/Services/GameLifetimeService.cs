using SeaBattle.Data;

namespace SeaBattle.Services
{
    public interface IGameLifetimeService
    {
        bool CheckRequiredStateWithGameState(GameState requiredState);

        void MoveNextState();

        void ClearGame();

        void FinishGame();
    }

    public class GameLifetimeService : IGameLifetimeService
    {
        private readonly Game _game;

        public GameLifetimeService(Game game)
        {
            _game = game;
        }

        public bool CheckRequiredStateWithGameState(GameState requiredState) => _game.State == requiredState;

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
