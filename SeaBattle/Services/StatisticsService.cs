using SeaBattle.Models;

namespace SeaBattle.Services
{
    public interface IStatisticsService
    {
        BattleStatistics GetBattleStatistics();
    }

    public class StatisticsService : IStatisticsService
    {
        public BattleStatistics BattleStatistics { get; set; }

        public StatisticsService()
        {
            BattleStatistics = new BattleStatistics();
        }

        public BattleStatistics GetBattleStatistics()
        {
            return new BattleStatistics();
        }
    }
}
