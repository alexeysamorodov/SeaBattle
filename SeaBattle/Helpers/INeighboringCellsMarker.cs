using SeaBattle.Data;

namespace SeaBattle.Helpers
{
    public interface INeighboringCellsMarker
    {
        void MarkNeighboringCells(ShipCoordinates shipCoords);
    }
}