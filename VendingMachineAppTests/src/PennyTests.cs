using NUnit.Framework;

namespace VendingMachineApp.src.Tests
{
    [TestFixture()]
    public class PennyTests
    {
        private Penny coin;

        [SetUp()]
        public void Init()
        {
            coin = new Penny();
        }

        [TearDown()]
        public void Dispose()
        {
            coin = null;
        }

        [Test()]
        public void WhenRequestingMassOfPennyShouldReturnExpectedMass()
        {
            Assert.That(coin.Mass == VendingMachineConstants.PENNY_MASS);
        }

        [Test()]
        public void WhenRequestingDiameterOfPennyShouldReturnExpectedDiameter()
        {
            Assert.That(coin.Diameter == VendingMachineConstants.PENNY_DIAMETER);
        }

        [Test()]
        public void WhenRequestingThicknessOfPennyShouldReturnExpectedThickness()
        {
            Assert.That(coin.Thickness == VendingMachineConstants.PENNY_THICKNESS);
        }
    }
}