using NUnit.Framework;

namespace VendingMachineApp.src.Tests
{
    [TestFixture()]
    public class NickelTests
    {
        private Nickel coin;

        [SetUp()]
        public void Init()
        {
            coin = new Nickel();
        }

        [TearDown()]
        public void Dispose()
        {
            coin = null;
        }

        [Test()]
        public void WhenRequestingMassOfNickelShouldReturnExpectedMass()
        {
            Assert.That(coin.Mass == VendingMachineConstants.NICKEL_MASS);
        }

        [Test()]
        public void WhenRequestingDiameterOfNickelShouldReturnExpectedDiameter()
        {
            Assert.That(coin.Diameter == VendingMachineConstants.NICKEL_DIAMETER);
        }

        [Test()]
        public void WhenRequestingThicknessOfNickelShouldReturnExpectedThickness()
        {
            Assert.That(coin.Thickness == VendingMachineConstants.NICKEL_THICKNESS);
        }
    }
}