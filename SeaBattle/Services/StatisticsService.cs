using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeaBattle.Models;

namespace SeaBattle.Services
{
    public interface IStatisticsService
    {
        BattleStatistics GetBattleStatistics();
    }

    public class StatisticsService
    {
    }
}
