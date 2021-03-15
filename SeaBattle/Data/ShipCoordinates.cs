namespace SeaBattle.Data
{
    public class ShipCoordinates
    {
        public Coordinates Begin { get; set; }
        public Coordinates End { get; set; }

        public ShipCoordinates(Coordinates begin, Coordinates end)
        {
            Begin = begin;
            End = end;
        }

        public override string ToString() => $"{Begin.StringRepresentation} {End.StringRepresentation}";
    }
}