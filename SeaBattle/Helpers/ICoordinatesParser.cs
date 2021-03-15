using SeaBattle.Data;

namespace SeaBattle.Helpers
{
    public interface ICoordinatesParser
    {
        ShipCoordinates[] ParseShipsCoordinates(string coords, int matrixSize);
        Coordinates ParseCoords(string strCoords, int matrixSize);
    }
}