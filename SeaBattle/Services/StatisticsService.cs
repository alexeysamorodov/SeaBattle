using System.Linq;
using SeaBattle.Data;
using SeaBattle.Models;

namespace SeaBattle.Services
{
    public interface IStatisticsService
    {
        BattleStatistics GetBattleStatistics();
        void IncrementShotsCount();
        void ClearStatistics();
    }

    public class StatisticsService : IStatisticsService
    {
        private readonly BattleStatistics _battleStatistics;
        private readonly Game _game;

        public StatisticsService(BattleStatistics battleStatistics, Game game)
        {
            _battleStatistics = battleStatistics;
            _game = game;
        }

        public BattleStatistics GetBattleStatistics()
        {
            _battleStatistics.ShipCount = _game.Ships.Count;
            _battleStatistics.DestroyedCount = _game.Ships.Count(s => s.IsDestroyed);
            _battleStatistics.KnockedCount = _game.Ships
                .Count(s => !s.IsDestroyed && s.Cells.Any(c => !c.IsAlive));
            return _battleStatistics;
        }

        public void IncrementShotsCount()
        {
            _battleStatistics.ShotCount++;
        }

        public void ClearStatistics()
        {
            //TODO: refactor clear BattleStatistics
            _battleStatistics.ShipCount = _battleStatistics.DestroyedCount =
                _battleStatistics.KnockedCount = _battleStatistics.ShotCount = 0;
        }
    }
}
