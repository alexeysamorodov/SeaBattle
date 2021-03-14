namespace SeaBattle.Services
{
    public interface ICreationService
    {
        void CreateMatrix(int size);

        void CreateShip(Coordinates start, Coordinates end);
    }
}