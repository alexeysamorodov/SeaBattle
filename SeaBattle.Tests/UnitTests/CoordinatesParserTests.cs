using NUnit.Framework;
using SeaBattle.Data;
using SeaBattle.Exceptions;
using SeaBattle.Helpers;

namespace SeaBattle.Tests.UnitTests
{
    [TestFixture]
    public class CoordinatesParserTests
    {
        protected readonly ICoordinatesParser _parser;
        protected const int CoordsLimit = int.MaxValue;

        public CoordinatesParserTests()
        {
            _parser = new CoordinatesParser();
        }

        [TestCase("1A", 0, 0)]
        [TestCase("26Z", 25, 25)]
        public void CoordinatesParserShould_ParseCellCoords(string strCoords, int x, int y)
        {
            var actual = _parser.ParseCellCoords(strCoords, CoordsLimit);
            Assert.AreEqual(x, actual.X);
            Assert.AreEqual(y, actual.Y);
        }

        [TestCase("11")]
        [TestCase("coords")]
        public void CoordinatesParserShould_ThrowException_WhenInvalidCellCoords(string strCoords)
        {
            Assert.Throws<BadCoordinatesException>(() => _parser.ParseCellCoords(strCoords, CoordsLimit));
        }

        [TestCase("4A", 3)]
        [TestCase("2C", 2)]
        public void CoordinatesParserShould_ThrowException_WhenCellCoordsOutOfCoordsLimit(string strCoords, int coordsLimit)
        {
            Assert.Throws<BadCoordinatesException>(() => _parser.ParseCellCoords(strCoords, coordsLimit));
        }

        [TestCase("1A 2B", 0, 0, 1, 1)]
        public void CoordinatesParserShould_ParseSingleShipCoords(string strCoords, int x1, int y1, int x2, int y2)
        {
            var actual = _parser.ParseShipCoordinates(strCoords, CoordsLimit);
            AssertShipCoordinatesAreEqual(actual, x1, y1, x2, y2);
        }

        [TestCase("1A 2B 3C 4A")]
        [TestCase("coords")]
        public void CoordinatesParserShould_ThrowException_WhenParseSingleInvalidShipCoords(string strCoords)
        {
            Assert.Throws<BadCoordinatesException>(() => _parser.ParseShipCoordinates(strCoords, CoordsLimit));
        }

        [TestCase("1A 2B,3D 3E",
            0, 0, 1, 1,
            2, 3, 2, 4)]
        public void CoordinatesParserShould_ParseSeveralShipsCoords(string strCoords,
            int x1_1, int y1_1, int x1_2, int y1_2,
            int x2_1, int y2_1, int x2_2, int y2_2)
        {
            var ships = _parser.ParseShipsCoordinates(strCoords, CoordsLimit);
            Assert.AreEqual(ships.Length, 2);
            AssertShipCoordinatesAreEqual(ships[0], x1_1, y1_1, x1_2, y1_2);
            AssertShipCoordinatesAreEqual(ships[1], x2_1, y2_1, x2_2, y2_2);
        }

        private void AssertShipCoordinatesAreEqual(ShipCoordinates actual, int x1, int y1, int x2, int y2)
        {
            Assert.AreEqual(x1, actual.Begin.X);
            Assert.AreEqual(y1, actual.Begin.Y);
            Assert.AreEqual(x2, actual.End.X);
            Assert.AreEqual(y2, actual.End.Y);
        }
    }
}