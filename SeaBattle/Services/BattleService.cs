using SeaBattle.Models;

namespace SeaBattle.Services
{
    interface IBattleService
    {
        ShotResult TakeShot(int row, int column);
    }

    public class BattleService
    {
    }
}
