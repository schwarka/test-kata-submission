using NUnit.Framework;

namespace VendingMachineApp.src.Tests
{
    [TestFixture()]
    public class QuarterTests
    {
        private Quarter coin;

        [SetUp()]
        public void Init()
        {
            coin = new Quarter();
        }

        [TearDown()]
        public void Dispose()
        {
            coin = null;
        }

        [Test()]
        public void WhenRequestingMassOfQuarterShouldReturnExpectedMass()
        {
            Assert.That(coin.Mass == VendingMachineConstants.QUARTER_MASS);
        }

        [Test()]
        public void WhenRequestingDiameterOfQuarterShouldReturnExpectedDiameter()
        {
            Assert.That(coin.Diameter == VendingMachineConstants.QUARTER_DIAMETER);
        }

        [Test()]
        public void WhenRequestingThicknessOfQuarterShouldReturnExpectedThickness()
        {
            Assert.That(coin.Thickness == VendingMachineConstants.QUARTER_THICKNESS);
        }
    }
}