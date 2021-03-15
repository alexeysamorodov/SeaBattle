using NUnit.Framework;
using SeaBattle.Data;
using SeaBattle.Helpers;
using SeaBattle.Services;

namespace SeaBattle.Tests.UnitTests
{
    [TestFixture]
    public class BattleServiceTests
    {
        private readonly ICreationService _creationService;
        private readonly IBattleService _battleService;

        public BattleServiceTests()
        {
            var game = new Game { Matrix = new Matrix(3) };
            var neighboringCellsMarker = new NeighboringCellsMarker(game);
            _creationService = new CreationService(game, neighboringCellsMarker);
            _battleService = new BattleService(game);
        }

        [Test]
        public void BattleServiceShould_DestroyShipAndFinishGame()
        {
            var oneCellShipCoords = new Coordinates(0, 0, "1A");
            var shipCoords = new ShipCoordinates(oneCellShipCoords, oneCellShipCoords);
            _creationService.CreateShips(new []{ shipCoords });
            var result = _battleService.TakeShot(oneCellShipCoords);
            Assert.That(result.IsDestroyed, Is.True);
            Assert.That(result.IsKnocked, Is.True);
            Assert.That(result.IsEndOfTheGame, Is.True);
        }

        [Test]
        public void BattleServiceShould_ReturnMissResult_WhenMiss()
        {
            var oneCellShipCoords = new Coordinates(0, 0, "1A");
            var emptyCell = new Coordinates(1, 1, "2B");
            var shipCoords = new ShipCoordinates(oneCellShipCoords, oneCellShipCoords);
            _creationService.CreateShips(new[] { shipCoords });
            var result = _battleService.TakeShot(emptyCell);
            Assert.That(result.IsDestroyed, Is.False);
            Assert.That(result.IsKnocked, Is.False);
            Assert.That(result.IsEndOfTheGame, Is.False);
        }
    }
}
