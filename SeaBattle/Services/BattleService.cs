using SeaBattle.Data;
using SeaBattle.Models;

namespace SeaBattle.Services
{
    public class BattleService: IBattleService
    {
        private readonly Game _game;

        public BattleService(Game game)
        {
            _game = game;
        }

        public ShotResult TakeShot(Coordinates shotCoords)
        {
            var cell = _game.Matrix[shotCoords];
            var shotResult = new ShotResult();
            if (cell != null)
            {
                cell.IsAlive = false;
                if (cell.Ship != null)
                {
                    shotResult.IsKnocked = true;
                    shotResult.IsDestroyed = cell.Ship.IsDestroyed;
                }
            }
            shotResult.IsEndOfTheGame = _game.AreAllShipsDestroyed;
            return shotResult;
        }

        public bool CheckCellIsAlive(Coordinates shotCoords)
        {
            var cell = _game.Matrix[shotCoords];
            return cell != null && !cell.IsAlive;
        }
    }
}
