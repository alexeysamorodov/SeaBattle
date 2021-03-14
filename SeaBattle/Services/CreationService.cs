using SeaBattle.Data;

namespace SeaBattle.Services
{
    public interface ICreationService
    {
        void CreateMatrix(int size);

        void CreateShip(Coordinates start, Coordinates end);
    }

    public class CreationService: ICreationService
    {
        private readonly Game _game;

        public CreationService(Game game)
        {
            _game = game;
        }

        public void CreateMatrix(int size)
        {
            _game.Matrix = new Matrix(size);
        }

        public void CreateShip(Coordinates start, Coordinates end)
        {
            var ship = new Ship();
            for (var x = start.X; x <= end.X; x++)
            for (var y = start.Y; y <= end.Y; y++)
            {
                var cell = new Cell();
                ship.AddCell(cell);
                _game.Matrix[x, y] = cell;
            }
            _game.Ships.Add(ship);
        }
    }
}
