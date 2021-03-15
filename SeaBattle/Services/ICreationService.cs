using SeaBattle.Data;

namespace SeaBattle.Services
{
    public interface ICreationService
    {
        void CreateMatrix(int size);

        void CreateShips(ShipCoordinates[] shipsCoords);
    }
}