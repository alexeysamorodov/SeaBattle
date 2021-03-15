using System;

namespace SeaBattle.Data
{
    public class Matrix
    {
        private const int MaxSize = 26;
        public Cell[,] Battlefield { get; set; }
        public int Size => Battlefield.GetLength(0);

        public Matrix(int size)
        {
            if (size > MaxSize)
                throw new Exception();
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
