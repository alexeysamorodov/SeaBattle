namespace SeaBattle.Data
{
    public class Cell
    {
        public string ShortName { get; set; }

        public Ship Ship { get; set; }

        public bool IsAlive { get; set; }
    }
}
