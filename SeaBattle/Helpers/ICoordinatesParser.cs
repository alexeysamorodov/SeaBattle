using SeaBattle.Data;

namespace SeaBattle.Helpers
{
    public interface ICoordinatesParser
    {
        ShipCoordinates[] ParseShipsCoordinates(string coords, int coordsLimit);

        ShipCoordinates ParseShipCoordinates(string strShipCoords, int coordsLimit);

        Coordinates ParseCellCoords(string strCoords, int coordsLimit);
    }
}