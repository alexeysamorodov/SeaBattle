using SeaBattle.Data;
using SeaBattle.Models;

namespace SeaBattle.Services
{
    public interface IBattleService
    {
        ShotResult TakeShot(Coordinates shotCoords);

        bool CheckCellShot(Coordinates shotCoords);
    }
}