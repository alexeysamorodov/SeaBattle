using SeaBattle.Data;

namespace SeaBattle.Helpers
{
    public class NeighboringCellsMarker : INeighboringCellsMarker
    {
        private readonly Game _game;

        public NeighboringCellsMarker(Game game)
        {
            _game = game;
        }

        public void MarkNeighboringCells(ShipCoordinates shipCoords)
        {
            MarkAboveNeighboringCells(shipCoords);
            MarkBelowNeighboringCells(shipCoords);
            MarkRightNeighboringCells(shipCoords);
            MarkLeftNeighboringCells(shipCoords);
        }

        private void MarkAboveNeighboringCells(ShipCoordinates shipCoords)
        {
            if (shipCoords.Begin.X == 0)
                return;
            var x = shipCoords.Begin.X - 1;
            MarkVerticalNeighboringCells(shipCoords, x);
        }

        private void MarkBelowNeighboringCells(ShipCoordinates shipCoords)
        {
            if (shipCoords.End.X == _game.Matrix.Size - 1)
                return;
            var x = shipCoords.End.X + 1;
            MarkVerticalNeighboringCells(shipCoords, x);
        }

        private void MarkVerticalNeighboringCells(ShipCoordinates shipCoords, int x)
        {
            var yStart = shipCoords.Begin.Y;
            if (shipCoords.Begin.Y > 0)
                yStart--;
            var yEnd = shipCoords.End.Y;
            if (shipCoords.End.Y < _game.Matrix.Size - 1)
                yEnd++;
            for (var j = yStart; j <= yEnd; j++)
            {
                var cell = _game.Matrix[x, j] ?? (_game.Matrix[x, j] = new Cell());
                cell.IsNextToShip = true;
            }
        }

        private void MarkRightNeighboringCells(ShipCoordinates shipCoords)
        {
            if (shipCoords.End.Y == _game.Matrix.Size - 1)
                return;
            var y = shipCoords.End.Y + 1;
            MarkHorizontalNeighboringCells(shipCoords, y);
        }

        private void MarkLeftNeighboringCells(ShipCoordinates shipCoords)
        {
            if (shipCoords.Begin.Y == 0)
                return;
            var y = shipCoords.Begin.Y - 1;
            MarkHorizontalNeighboringCells(shipCoords, y);
        }

        private void MarkHorizontalNeighboringCells(ShipCoordinates shipCoords, int y)
        {
            var xStart = shipCoords.Begin.X;
            var xEnd = shipCoords.End.X;
            for (var i = xStart; i <= xEnd; i++)
            {
                var cell = _game.Matrix[i, y] ?? (_game.Matrix[i, y] = new Cell());
                cell.IsNextToShip = true;
            }
        }
    }
}
