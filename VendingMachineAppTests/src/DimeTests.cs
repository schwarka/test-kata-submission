using NUnit.Framework;

namespace VendingMachineApp.src.Tests
{
    [TestFixture()]
    public class DimeTests
    {
        private Dime coin;

        [SetUp()]
        public void Init()
        {
            coin = new Dime();
        }

        [TearDown()]
        public void Dispose()
        {
            coin = null;
        }

        [Test()]
        public void WhenRequestingMassOfDimeShouldReturnExpectedMass()
        {
            Assert.That(coin.Mass == VendingMachineConstants.DIME_MASS);
        }

        [Test()]
        public void WhenRequestingDiameterOfDimeShouldReturnExpectedDiameter()
        {
            Assert.That(coin.Diameter == VendingMachineConstants.DIME_DIAMETER);
        }

        [Test()]
        public void WhenRequestingThicknessOfDimeShouldReturnExpectedThickness()
        {
            Assert.That(coin.Thickness == VendingMachineConstants.DIME_THICKNESS);
        }
    }
}