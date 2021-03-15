using SeaBattle.Models;

namespace SeaBattle.Services
{
    public interface IStatisticsService
    {
        BattleStatistics GetBattleStatistics();
        void IncrementShotsCount();
        void ClearStatistics();
    }
}