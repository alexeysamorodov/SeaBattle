using SeaBattle.Data;

namespace SeaBattle.Services
{
    interface ICreationService
    {
        Matrix CreateMatrix(int size);

        Ship CreateShip(int x1, int y1, int x2, int y2);
    }

    public class CreationService
    {
    }
}
