using System;
using SeaBattle.Data;
using SeaBattle.Exceptions;
using SeaBattle.Helpers;

namespace SeaBattle.Services
{
    public class CreationService: ICreationService
    {
        private readonly Game _game;
        private readonly INeighboringCellsMarker _neighboringCellsMarker;

        public CreationService(Game game,
                               INeighboringCellsMarker neighboringCellsMarker)
        {
            _game = game;
            _neighboringCellsMarker = neighboringCellsMarker;
        }

        public void CreateMatrix(int size)
        {
            _game.Matrix = new Matrix(size);
        }

        public void CreateShips(ShipCoordinates[] shipsCoords)
        {
            foreach (var shipCoords in shipsCoords)
            {
                if (IsBuildingImpossible(shipCoords))
                    throw new ShipIntersectionException(shipCoords.ToString());
                CreateShip(shipCoords);
                _neighboringCellsMarker.MarkNeighboringCells(shipCoords);
            }
        }

        private bool IsBuildingImpossible(ShipCoordinates shipCoords)
        {
            for (var x = shipCoords.Begin.X; x <= shipCoords.End.X; x++)
            for (var y = shipCoords.Begin.Y; y <= shipCoords.End.Y; y++)
            {
                var cell = _game.Matrix[x, y];
                if (cell != null && (cell.IsPartOfShip || cell.IsNextToShip))
                    return true;
            }
            return false;
        }

        private void CreateShip(ShipCoordinates shipCoords)
        {
            var ship = new Ship();
            for (var x = shipCoords.Begin.X; x <= shipCoords.End.X; x++)
            for (var y = shipCoords.Begin.Y; y <= shipCoords.End.Y; y++)
            {
                var cell = new Cell();
                ship.AddCell(cell);
                _game.Matrix[x, y] = cell;
            }
            _game.Ships.Add(ship);
        }
    }
}
