namespace SeaBattle.Exceptions
{
    public class ShipIntersectionException : BadCoordinatesException
    {
        public ShipIntersectionException(string badStringCoordinates) 
            : base(badStringCoordinates)
        {
        }

        public override string ToString()
        {
            return $"Ship with coordinates: {BadCoordinates} intersects previous ships";
        }
    }
}