using System;

namespace SeaBattle.Exceptions
{
    public class BadCoordinatesException: Exception
    {
        protected string BadCoordinates;
        public BadCoordinatesException(string badStringCoordinates)
        {
            BadCoordinates = badStringCoordinates;
        }

        public override string ToString()
        {
            return $"Invalid coordinates: {BadCoordinates}";
        }
    }
}
