using NUnit.Framework;
using SeaBattle.Data;
using SeaBattle.Exceptions;
using SeaBattle.Helpers;
using SeaBattle.Services;

namespace SeaBattle.Tests.UnitTests
{
    [TestFixture]
    public class CreationServiceTests
    {
        private readonly ICreationService _creationService;
        private readonly Game _game;

        public CreationServiceTests()
        {
            _game = new Game {Matrix = new Matrix(3)};
            var neighboringCellsMarker = new NeighboringCellsMarker(_game);
            _creationService = new CreationService(_game, neighboringCellsMarker);
        }

        [TestCaseSource(nameof(NotIntersectedShipsCases))]
        public void CreationServiceShould_CreateNotIntersectedShips(ShipCoordinates[] shipsCoords)
        {
            _creationService.CreateShips(shipsCoords);
            Assert.That(_game.Ships.Count, Is.EqualTo(2));
        }

        [TestCaseSource(nameof(IntersectedShipsCases))]
        public void CreationServiceShould_ThrowException_WhenCreateIntersectedShips(ShipCoordinates[] shipsCoords)
        {
            Assert.Throws<ShipIntersectionException>(() => _creationService.CreateShips(shipsCoords));
            Assert.That(_game.Ships.Count, Is.EqualTo(2));
        }

        private static readonly object[] NotIntersectedShipsCases =
        {
            new object[]
            {
                new[]
                {
                    new ShipCoordinates(new Coordinates(0, 0, "1A"), new Coordinates(0, 0, "1A")),
                    new ShipCoordinates(new Coordinates(0, 2, "3A"), new Coordinates(0, 2, "3A")),
                }
            }
        };

        private static readonly object[] IntersectedShipsCases =
        {
            new object[]
            {
                new[]
                {
                    new ShipCoordinates(new Coordinates(0, 0, "1A"), new Coordinates(0, 0, "1A")),
                    new ShipCoordinates(new Coordinates(0, 2, "1C"), new Coordinates(0, 2, "1C")),
                    new ShipCoordinates(new Coordinates(1, 1, "2B"), new Coordinates(2, 2, "3C")),
                }
            }
        };
    }
}
