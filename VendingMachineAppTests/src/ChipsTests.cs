using NUnit.Framework;

namespace VendingMachineApp.src.Tests
{
    [TestFixture()]
    public class ChipsTests
    {
        private Chips product;

        [SetUp]
        public void Init()
        {
            product = new Chips();
        }

        [TearDown]
        public void Dispose()
        {
            product = null;
        }

        [Test()]
        public void WhenInstantiedChipsShouldHaveExpectedStock()
        {
            Assert.That(product.Stock == VendingMachineConstants.CHIPS_STOCK);
        }

        [Test()]
        public void WhenRequestingPriceOfChipsItShouldReturnExpectedPrice()
        {
            Assert.That(product.Price == VendingMachineConstants.CHIPS_PRICE);
        }

        [Test()]
        public void WhenABagOfChipsIsPurchasedItsRemainingStockShouldGoDownByOne()
        {
            int initialStock = product.Stock;
            product.Purchase();
            Assert.That((initialStock - product.Stock) == 1);
        }

        [Test()]
        public void WhenStockIsZeroItShouldReturnFalseOnAttemptedPurchase()
        {
            while (product.Stock != 0)
                product.Purchase();

            Assert.False(product.Purchase());
        }

        [Test()]
        public void WhenStockIsZeroItShouldRemainZeroAfterAttemptedPurchase()
        {
            while (product.Stock != 0)
                product.Purchase();

            product.Purchase();
            Assert.That(product.Stock == 0);
        }
    }
}