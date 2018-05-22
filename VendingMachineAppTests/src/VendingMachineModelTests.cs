using NUnit.Framework;
using VendingMachineApp.src;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using Moq;

namespace VendingMachineApp.Tests
{
    [TestFixture()]
    public class VendingMachineModelTests
    {
        private VendingMachineModel model;
        private Quarter quarter = new Quarter();
        private Dime dime = new Dime();
        private Nickel nickel = new Nickel();
        private Penny penny = new Penny();
        private Cola cola;
        private Chips chips;
        private Candy candy;

        [SetUp()]
        public void Init()
        {
            //  Restock products and reintialize our model before each tests.
            cola = new Cola();
            chips = new Chips();
            candy = new Candy();
            model = new VendingMachineModel(new VendingMachineTimer());
        }

        [TearDown()]
        public void Dispose()
        {
            cola = null;
            chips = null;
            candy = null;
            model = null;
        }

        [Test()]
        public void WhenQuarterIsInsertedItShouldAddTwentyFiveCentsToCurrentTotal()
        {
            double previousTotal = model.Total;
            model.InsertCoin(quarter);
            Assert.That((model.Total - previousTotal) == VendingMachineConstants.QUARTER_VALUE);
        }

        [Test()]
        public void WhenDimeIsInsertedItShouldAddTenCentsToCurrentTotal()
        {
            double previousTotal = model.Total;
            model.InsertCoin(dime);
            Assert.That((model.Total - previousTotal) == VendingMachineConstants.DIME_VALUE);
        }
        
        [Test()]
        public void WhenNickelIsInsertedItShouldAddFiveCentsToCurrentTotal()
        {
            double previousTotal = model.Total;
            model.InsertCoin(nickel);
            Assert.That((model.Total - previousTotal) == VendingMachineConstants.NICKEL_VALUE);
        }

        [Test()]
        public void WhenPennyIsInsertedItShouldAddZeroCentsToCurrentTotal()
        {
            double previousTotal = model.Total;
            model.InsertCoin(penny);
            Assert.That((model.Total - previousTotal) == 0);
        }

        [Test()]
        public void WhenQuarterIsInsertedItShouldAddQuarterToInsertedCoinList()
        {
            model.InsertCoin(quarter);
            Assert.That(model.InsertedCoins.Contains(quarter));
        }

        [Test()]
        public void WhenDimeIsInsertedItShouldAddDimeToInsertedCoinList()
        {
            model.InsertCoin(dime);
            Assert.That(model.InsertedCoins.Contains(dime));
        }

        [Test()]
        public void WhenNickelIsInsertedItShouldAddNickelToInsertedCoinList()
        {
            model.InsertCoin(nickel);
            Assert.That(model.InsertedCoins.Contains(nickel));
        }

        [Test()]
        public void WhenPennyIsInsertedItShouldNotAddPennyToInsertedCoinList()
        {
            model.InsertCoin(penny);
            Assert.That(!model.InsertedCoins.Contains(penny));
        }

        [Test()]
        public void WhenPennyIsInsertedItShouldAddOnePennyToCoinReturn()
        {
            Penny coin = penny;
            model.InsertCoin(coin);
            Assert.That(model.ReturnedCoins.Contains(coin));
        }

        [Test()]
        public void WhenReturnCoinsIsCalledItShouldPlaceAllInsertedCoinsIntoReturnedCoinsList()
        {    
            model.InsertCoin(quarter);
            model.InsertCoin(dime);
            model.InsertCoin(penny);
            model.InsertCoin(quarter);

            List<ICoin> expectedCoinsReturned = new List<ICoin> { penny, quarter, dime, quarter };
            model.ReturnCoins();
            Assert.That(model.ReturnedCoins.SequenceEqual(expectedCoinsReturned));
        }

        [Test()]
        public void WhenReturnCoinsIsCalledItShouldClearInsertedCoinsList()
        {
            model.InsertCoin(quarter);
            model.InsertCoin(dime);
            model.InsertCoin(penny);
            model.InsertCoin(quarter);

            List<ICoin> expectedInsertedCoins = new List<ICoin> { };
            model.ReturnCoins();
            Assert.That(model.InsertedCoins.SequenceEqual(expectedInsertedCoins));
        }

        [Test()]
        public void WhenPurchaseIsSuccessfulItShouldReturnTrue()
        {
            model.InsertCoin(quarter);
            model.InsertCoin(quarter);

            Assert.That(model.Purchase(chips));
        }

        [Test()]
        public void WhenPurchaseIsSuccessfulItShouldChangeStateToPurchaseCompleted()
        {
            model.InsertCoin(quarter);
            model.InsertCoin(quarter);
            model.Purchase(chips);
            Assert.That(model.CurrentState.Equals(VENDING_MACHINE_STATE.PURCHASE_COMPLETED));
        }

        [Test()]
        public void WhenPurchaseIsCalledOnProductWithInsufficientStockItShouldReturnFalse()
        {
            while (chips.Stock != 0)
                chips.Purchase();
            chips.Purchase();
            Assert.False(model.Purchase(chips));
        }

        [Test()]
        public void WhenPurchaseIsCalledOnProductWithInsufficientStockItShouldChangeStateToOutOfStock()
        {
            while (chips.Stock != 0)
                chips.Purchase();
            model.Purchase(chips);
            Assert.That(model.CurrentState.Equals(VENDING_MACHINE_STATE.SOLD_OUT));
        }

        [Test()]
        public void WhenPurchaseIsCalledOnProductWithInsufficientFundsItShouldReturnFalse()
        {
            Assert.False(model.Purchase(chips));
        }

        [Test()]
        public void WhenPurchaseIsCalledOnProductWithInsufficientFundsItShouldChangeStateToPriceCheck()
        {
            model.Purchase(chips);
            Assert.That(model.CurrentState.Equals(VENDING_MACHINE_STATE.PRICE_CHECK));
        }

        [Test()]
        public void WhenPurchaseRequiresExactChangeButDoesNotRecieveExactChangeItShouldReturnFalse()
        {
            model.EmptyMachineCoins();

            model.InsertCoin(quarter);
            model.InsertCoin(quarter);
            model.InsertCoin(nickel);
            model.Purchase(chips);
            Assert.False(model.Purchase(chips));
        }

        [Test()]
        public void WhenPurchaseRequiresExactChangeAndDoesNotRecieveExactChangeItShouldChangeStateToExactChangeOnly()
        {
            model.EmptyMachineCoins();

            model.InsertCoin(quarter);
            model.InsertCoin(quarter);
            model.InsertCoin(nickel);
            model.Purchase(chips);
            Assert.That(model.CurrentState.Equals(VENDING_MACHINE_STATE.EXACT_CHANGE_ONLY));
        }

        public void WhenPurchaseRequiresExactChangeAndDoesNotRecieveExactChangeItShouldReturnCoins()
        {
            model.EmptyMachineCoins();

            model.InsertCoin(quarter);
            model.InsertCoin(quarter);
            model.InsertCoin(nickel);
            model.Purchase(chips);
            Assert.That(model.ReturnedCoins.SequenceEqual(new List<ICoin>() { quarter, quarter, nickel }));
        }

        [Test()]
        public void WhenPurchaseRequiresExactChangeAndDoesRecieveExactChangeItShouldReturnTrue()
        {
            model.EmptyMachineCoins();

            model.InsertCoin(quarter);
            model.InsertCoin(quarter);
            Assert.True(model.Purchase(chips));
        }

        [Test()]
        public void WhenPurchaseRequiresExactChangeAndDoesRecieveExactChangeItShouldChangeStateToPurchaseCompleted()
        {
            model.EmptyMachineCoins();
            model.InsertCoin(quarter);
            model.InsertCoin(quarter);
            model.Purchase(chips);
            Assert.That(model.CurrentState.Equals(VENDING_MACHINE_STATE.PURCHASE_COMPLETED));
        }
      

        class WhenMakeChangeIsCalledItShouldReturnCorrectAmountOfChange_TestCaseData : VendingMachineModelTests, IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                Init();
                yield return new object[] { quarter, quarter, quarter, quarter, quarter, cola, new List<ICoin> { quarter } };
                yield return new object[] { quarter, quarter, quarter, quarter, penny, cola, new List<ICoin> { penny } };
                yield return new object[] { quarter, quarter, dime, quarter, quarter, cola, new List<ICoin> { dime } };
                yield return new object[] { nickel, nickel, dime, quarter, dime, chips, new List<ICoin> { nickel } };
                yield return new object[] { quarter, quarter, dime, quarter, dime, chips, new List<ICoin> { quarter, dime, dime } };
                yield return new object[] { quarter, dime, dime, dime, dime, chips, new List<ICoin> { dime, nickel } };
                yield return new object[] { dime, dime, nickel, quarter, penny, chips, new List<ICoin> { penny } };
                yield return new object[] { dime, dime, nickel, quarter, quarter, candy, new List<ICoin> { dime } };
                yield return new object[] { quarter, quarter, nickel, quarter, penny, candy, new List<ICoin> { penny, dime, nickel } };
                yield return new object[] { quarter, dime, dime, dime, dime, candy, new List<ICoin> { } };
            }
        }

        [TestCaseSource(typeof(WhenMakeChangeIsCalledItShouldReturnCorrectAmountOfChange_TestCaseData))]
        public void WhenMakeChangeIsCalledItShouldReturnCorrectAmountOfChange(ICoin coin1, ICoin coin2, ICoin coin3, ICoin coin4, ICoin coin5, IProduct product, List<ICoin> expectedResult)
        {
            model.InsertCoin(coin1);
            model.InsertCoin(coin2);
            model.InsertCoin(coin3);
            model.InsertCoin(coin4);
            model.InsertCoin(coin5);

            model.Purchase(product);
            Assert.That(model.ReturnedCoins.SequenceEqual(expectedResult));
        }

        [Test()]
        public void WhenCurrentStateUpdatesToNewStateItShouldBeginTimer()
        {
            Mock<ITimer> mockTimer = new Mock<ITimer>();
            VendingMachineModel model = new VendingMachineModel(mockTimer.Object);
            model.Purchase(new Chips());
            mockTimer.Verify(x => x.Start(), Times.Once);
        }

        internal class WhenTimedOutIsCalled : VendingMachineModelTests {

            internal class WhenCurrentStateEqualsInsertCoins : WhenTimedOutIsCalled
            {
                [SetUp()]
                public void TestFixtureSetup()
                {
                    model.CurrentState = VENDING_MACHINE_STATE.INSERT_COINS;
                }

                [Test()]
                public void WhenExactChangeIsNeededAndTotalIsZeroItShouldUpdateToExpectedState()
                {
                    model.EmptyMachineCoins();
                    model.TimedOut(this, null);
                    Assert.True(model.CurrentState.Equals(VENDING_MACHINE_STATE.EXACT_CHANGE_ONLY));
                }

                [Test()]
                public void WhenExactChangeIsNeededAndTotalIsNotZeroItShouldUpdateToExpectedState()
                {
                    model.EmptyMachineCoins();
                    model.InsertCoin(new Quarter());
                    model.TimedOut(this, null);
                    Assert.True(model.CurrentState.Equals(VENDING_MACHINE_STATE.DISPLAY_TOTAL));
                }

                [Test()]
                public void WhenExactChangeIsNotNeededAndTotalIsZeroItShouldUpdateToExpectedState()
                {
                    model.TimedOut(this, null);
                    Assert.True(model.CurrentState.Equals(VENDING_MACHINE_STATE.INSERT_COINS));
                }

                [Test()]
                public void WhenExactChangeIsNotNeededAndTotalIsNotZeroItShouldUpdateToExpectedState()
                {
                    model.InsertCoin(new Quarter());
                    model.TimedOut(this, null);
                    Assert.True(model.CurrentState.Equals(VENDING_MACHINE_STATE.DISPLAY_TOTAL));
                }
            }
            internal class WhenCurrentStateEqualsExactChangeOnly : WhenTimedOutIsCalled
            {
                [SetUp()]
                public void TestFixtureSetup()
                {
                    model.CurrentState = VENDING_MACHINE_STATE.EXACT_CHANGE_ONLY;
                }

                [Test()]
                public void WhenExactChangeIsNeededAndTotalIsZeroItShouldUpdateToExpectedState()
                {
                    model.EmptyMachineCoins();
                    model.TimedOut(this, null);
                    Assert.True(model.CurrentState.Equals(VENDING_MACHINE_STATE.EXACT_CHANGE_ONLY));
                }

                [Test()]
                public void WhenExactChangeIsNeededAndTotalIsNotZeroItShouldUpdateToExpectedState()
                {
                    model.EmptyMachineCoins();
                    model.InsertCoin(new Quarter());
                    model.TimedOut(this, null);
                    Assert.True(model.CurrentState.Equals(VENDING_MACHINE_STATE.DISPLAY_TOTAL));
                }

                [Test()]
                public void WhenExactChangeIsNotNeededAndTotalIsZeroItShouldUpdateToExpectedState()
                {
                    model.TimedOut(this, null);
                    Assert.True(model.CurrentState.Equals(VENDING_MACHINE_STATE.INSERT_COINS));
                }

                [Test()]
                public void WhenExactChangeIsNotNeededAndTotalIsNotZeroItShouldUpdateToExpectedState()
                {
                    model.InsertCoin(new Quarter());
                    model.TimedOut(this, null);
                    Assert.True(model.CurrentState.Equals(VENDING_MACHINE_STATE.DISPLAY_TOTAL));
                }
            }
            internal class WhenCurrentStateEqualsDisplayTotal : WhenTimedOutIsCalled
            {
                [SetUp()]
                public void TestFixtureSetup()
                {
                    model.CurrentState = VENDING_MACHINE_STATE.DISPLAY_TOTAL;
                }

                [Test()]
                public void WhenExactChangeIsNeededAndTotalIsZeroItShouldUpdateToExpectedState()
                {
                    model.EmptyMachineCoins();
                    model.TimedOut(this, null);
                    Assert.True(model.CurrentState.Equals(VENDING_MACHINE_STATE.EXACT_CHANGE_ONLY));
                }

                [Test()]
                public void WhenExactChangeIsNeededAndTotalIsNotZeroItShouldUpdateToExpectedState()
                {
                    model.EmptyMachineCoins();
                    model.InsertCoin(new Quarter());
                    model.TimedOut(this, null);
                    Assert.True(model.CurrentState.Equals(VENDING_MACHINE_STATE.DISPLAY_TOTAL));
                }

                [Test()]
                public void WhenExactChangeIsNotNeededAndTotalIsZeroItShouldUpdateToExpectedState()
                {
                    model.TimedOut(this, null);
                    Assert.True(model.CurrentState.Equals(VENDING_MACHINE_STATE.INSERT_COINS));
                }

                [Test()]
                public void WhenExactChangeIsNotNeededAndTotalIsNotZeroItShouldUpdateToExpectedState()
                {
                    model.InsertCoin(new Quarter());
                    model.TimedOut(this, null);
                    Assert.True(model.CurrentState.Equals(VENDING_MACHINE_STATE.DISPLAY_TOTAL));
                }
            }
            internal class WhenCurrentStateEqualsPurchaseComplete : WhenTimedOutIsCalled
            {
                [SetUp()]
                public void TestFixtureSetup()
                {
                    model.CurrentState = VENDING_MACHINE_STATE.PURCHASE_COMPLETED;
                }

                [Test()]
                public void WhenExactChangeIsNeededAndTotalIsZeroItShouldUpdateToExpectedState()
                {
                    model.EmptyMachineCoins();
                    model.TimedOut(this, null);
                    Assert.True(model.CurrentState.Equals(VENDING_MACHINE_STATE.EXACT_CHANGE_ONLY));
                }

                [Test()]
                public void WhenExactChangeIsNeededAndTotalIsNotZeroItShouldUpdateToExpectedState()
                {
                    model.EmptyMachineCoins();
                    model.InsertCoin(new Quarter());
                    model.TimedOut(this, null);
                    Assert.True(model.CurrentState.Equals(VENDING_MACHINE_STATE.DISPLAY_TOTAL));
                }

                [Test()]
                public void WhenExactChangeIsNotNeededAndTotalIsZeroItShouldUpdateToExpectedState()
                {
                    model.TimedOut(this, null);
                    Assert.True(model.CurrentState.Equals(VENDING_MACHINE_STATE.INSERT_COINS));
                }

                [Test()]
                public void WhenExactChangeIsNotNeededAndTotalIsNotZeroItShouldUpdateToExpectedState()
                {
                    model.InsertCoin(new Quarter());
                    model.TimedOut(this, null);
                    Assert.True(model.CurrentState.Equals(VENDING_MACHINE_STATE.DISPLAY_TOTAL));
                }
            }
            internal class WhenCurrentStateEqualsPriceCheck : WhenTimedOutIsCalled
            {
                [SetUp()]
                public void TestFixtureSetup()
                {
                    model.CurrentState = VENDING_MACHINE_STATE.PRICE_CHECK;
                }

                [Test()]
                public void WhenExactChangeIsNeededAndTotalIsZeroItShouldUpdateToExpectedState()
                {
                    model.EmptyMachineCoins();
                    model.TimedOut(this, null);
                    Assert.True(model.CurrentState.Equals(VENDING_MACHINE_STATE.EXACT_CHANGE_ONLY));
                }

                [Test()]
                public void WhenExactChangeIsNeededAndTotalIsNotZeroItShouldUpdateToExpectedState()
                {
                    model.EmptyMachineCoins();
                    model.InsertCoin(new Quarter());
                    model.TimedOut(this, null);
                    Assert.True(model.CurrentState.Equals(VENDING_MACHINE_STATE.DISPLAY_TOTAL));
                }

                [Test()]
                public void WhenExactChangeIsNotNeededAndTotalIsZeroItShouldUpdateToExpectedState()
                {
                    model.TimedOut(this, null);
                    Assert.True(model.CurrentState.Equals(VENDING_MACHINE_STATE.INSERT_COINS));
                }

                [Test()]
                public void WhenExactChangeIsNotNeededAndTotalIsNotZeroItShouldUpdateToExpectedState()
                {
                    model.InsertCoin(new Quarter());
                    model.TimedOut(this, null);
                    Assert.True(model.CurrentState.Equals(VENDING_MACHINE_STATE.DISPLAY_TOTAL));
                }
            }
            internal class WhenCurrentStateEqualsOutOfStock : WhenTimedOutIsCalled
            {
                [SetUp()]
                public void TestFixtureSetup()
                {
                    model.CurrentState = VENDING_MACHINE_STATE.SOLD_OUT;
                }

                [Test()]
                public void WhenExactChangeIsNeededAndTotalIsZeroItShouldUpdateToExpectedState()
                {
                    model.EmptyMachineCoins();
                    model.TimedOut(this, null);
                    Assert.True(model.CurrentState.Equals(VENDING_MACHINE_STATE.EXACT_CHANGE_ONLY));
                }

                [Test()]
                public void WhenExactChangeIsNeededAndTotalIsNotZeroItShouldUpdateToExpectedState()
                {
                    model.EmptyMachineCoins();
                    model.InsertCoin(new Quarter());
                    model.TimedOut(this, null);
                    Assert.True(model.CurrentState.Equals(VENDING_MACHINE_STATE.DISPLAY_TOTAL));
                }

                [Test()]
                public void WhenExactChangeIsNotNeededAndTotalIsZeroItShouldUpdateToExpectedState()
                {
                    model.TimedOut(this, null);
                    Assert.True(model.CurrentState.Equals(VENDING_MACHINE_STATE.INSERT_COINS));
                }

                [Test()]
                public void WhenExactChangeIsNotNeededAndTotalIsNotZeroItShouldUpdateToExpectedState()
                {
                    model.InsertCoin(new Quarter());
                    model.TimedOut(this, null);
                    Assert.True(model.CurrentState.Equals(VENDING_MACHINE_STATE.DISPLAY_TOTAL));
                }
            }
        }
    }
}