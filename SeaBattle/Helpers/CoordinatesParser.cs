using System;
using System.Linq;
using SeaBattle.Data;
using SeaBattle.Exceptions;

namespace SeaBattle.Helpers
{
    public class CoordinatesParser: ICoordinatesParser
    {
        public ShipCoordinates[] ParseShipsCoordinates(string coords, int matrixSize) =>
            coords.Split(',')
                  .Select(s => s.Trim())
                  .Select(shipCoords => ParseShipCoordinates(shipCoords, matrixSize))
                  .ToArray();

        public Coordinates ParseCoords(string strCoords, int matrixSize)
        {
            try
            {
                var x = int.Parse(strCoords.Substring(0, strCoords.Length - 1)) - 1;
                var y = strCoords[^1] - 'A';
                if (x < 0 || y < 0 || x >= matrixSize || y >= matrixSize)
                    throw new Exception();
                return new Coordinates(x, y, strCoords);
            }
            catch (Exception)
            {
                throw new BadCoordinatesException(strCoords);
            }
        }

        private ShipCoordinates ParseShipCoordinates(string strShipCoords, int matrixSize)
        {
            try
            {
                var beginEndCoords = strShipCoords.Split();
                var begin = ParseCoords(beginEndCoords[0], matrixSize);
                var end = ParseCoords(beginEndCoords[1], matrixSize);
                if (beginEndCoords.Length != 2 || !(begin <= end))
                    throw new Exception();
                return new ShipCoordinates(begin, end);
            }
            catch (Exception)
            {
                throw new BadCoordinatesException(strShipCoords);
            }
        }
    }
}