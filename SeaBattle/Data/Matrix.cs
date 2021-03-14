using SeaBattle.Services;

namespace SeaBattle.Data
{
    public class Matrix
    {
        public Cell[,] Battlefield { get; set; }

        public Matrix(int size)
        {
            Battlefield = new Cell[size,size];
        }

        public Cell this[int x, int y]
        {
            get => Battlefield[x, y];
            set => Battlefield[x, y] = value;
        }

        public Cell this[Coordinates coords]
        {
            get => this[coords.X, coords.Y];
            set => this[coords.X, coords.Y] = value;
        }
    }
}
