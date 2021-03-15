using SeaBattle.Data;

namespace SeaBattle.Services
{
    public class GameLifetimeService : IGameLifetimeService
    {
        private readonly Game _game;
        private readonly IStatisticsService _statisticsService;

        public GameLifetimeService(Game game,
                                   IStatisticsService statisticsService)
        {
            _game = game;
            _statisticsService = statisticsService;
        }

        public GameState GetGameState() => _game.State;

        public void MoveNextState()
        {
            if (_game.State < GameState.Finished)
                _game.State++;
        }

        public void ClearGame()
        {
            _game.Clear();
            _statisticsService.ClearStatistics();
        }

        public void FinishGame()
        {
            _game.State = GameState.Finished;
        }
    }
}
