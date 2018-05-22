using NUnit.Framework;

namespace VendingMachineApp.src.Tests
{
    [TestFixture()]
    public class CandyTests
    {
        private Candy product;

        [SetUp]
        public void Init()
        {
            product = new Candy();
        }

        [TearDown]
        public void Dispose()
        {
            product = null;
        }

        [Test()]
        public void WhenInstantiedCandyShouldHaveExpectedStock()
        {
            Assert.That(product.Stock == VendingMachineConstants.CANDY_STOCK);
        }

        [Test()]
        public void WhenRequestingPriceOfCandyItShouldReturnExpectedPrice()
        {
            Assert.That(product.Price == VendingMachineConstants.CANDY_PRICE);
        }

        [Test()]
        public void WhenACandyIsPurchasedItsRemainingStockShouldGoDownByOne()
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