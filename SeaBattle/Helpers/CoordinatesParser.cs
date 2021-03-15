using System;
using System.Linq;
using SeaBattle.Data;
using SeaBattle.Exceptions;

namespace SeaBattle.Helpers
{
    public class CoordinatesParser: ICoordinatesParser
    {
        public ShipCoordinates[] ParseShipsCoordinates(string coords, int coordsLimit) =>
            coords.Split(',')
                  .Select(s => s.Trim())
                  .Select(shipCoords => ParseShipCoordinates(shipCoords, coordsLimit))
                  .ToArray();

        public Coordinates ParseCellCoords(string strCoords, int coordsLimit)
        {
            try
            {
                var x = int.Parse(strCoords.Substring(0, strCoords.Length - 1)) - 1;
                var y = strCoords[^1] - 'A';
                if (x < 0 || y < 0 || x >= coordsLimit || y >= coordsLimit)
                    throw new Exception();
                return new Coordinates(x, y, strCoords);
            }
            catch (Exception)
            {
                throw new BadCoordinatesException(strCoords);
            }
        }

        public ShipCoordinates ParseShipCoordinates(string strShipCoords, int coordsLimit)
        {
            try
            {
                var beginEndCoords = strShipCoords.Split();
                var begin = ParseCellCoords(beginEndCoords[0], coordsLimit);
                var end = ParseCellCoords(beginEndCoords[1], coordsLimit);
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