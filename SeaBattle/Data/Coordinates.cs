namespace SeaBattle.Data
{
    public class Coordinates
    {
        public int X { get; set; }

        public int Y { get; set; }

        public string StringRepresentation { get; set; }

        public Coordinates(int x, int y, string strCoords)
        {
            X = x;
            Y = y;
            StringRepresentation = strCoords;
        }

        public static bool operator <=(Coordinates first, Coordinates second) => first.X <= second.X && first.Y <= second.Y;

        public static bool operator >=(Coordinates first, Coordinates second) => second <= first;
    }
}