namespace SeaBattle.Data
{
    public class Cell
    {
        public Ship Ship { get; set; }

        public bool IsPartOfShip => Ship != null;

        public bool IsNextToShip { get; set; }

        public bool IsAlive { get; set; } = true;
    }
}