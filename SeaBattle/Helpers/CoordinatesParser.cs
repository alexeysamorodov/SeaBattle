using SeaBattle.Services;

namespace SeaBattle.Helpers
{
    public interface ICoordinatesParser
    {
        Coordinates ParseCoords(string strCoords);
    }

    public class CoordinatesParser: ICoordinatesParser
    {
        public Coordinates ParseCoords(string strCoords)
        {
            return new Coordinates
            {
                Y = strCoords[^1] - 'A',
                X = int.Parse(strCoords.Substring(0, strCoords.Length - 1)) - 1
            };
        }
    }
}