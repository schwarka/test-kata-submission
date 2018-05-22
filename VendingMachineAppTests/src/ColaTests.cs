using NUnit.Framework;

namespace VendingMachineApp.src.Tests
{
    [TestFixture()]
    public class ColaTests
    {
        private Cola product;

        [SetUp]
        public void Init()
        {
            product = new Cola();
        }

        [TearDown]
        public void Dispose()
        {
            product = null;
        }

        [Test()]
        public void WhenInstantiedColaShouldHaveExpectedStock()
        {
            Assert.That(product.Stock == VendingMachineConstants.COLA_STOCK);
        }

        [Test()]
        public void WhenRequestingPriceOfColaItShouldReturnExpectedPrice()
        {
            Assert.That(product.Price == VendingMachineConstants.COLA_PRICE);
        }

        [Test()]
        public void WhenAColaIsPurchasedItsRemainingStockShouldGoDownByOne()
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