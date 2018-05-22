using NUnit.Framework;

namespace VendingMachineApp.src.Tests
{
    [TestFixture()]
    public class VendingMachineControllerTests
    {
        private VendingMachineModel model;
        private VendingMachineController controller;

        [SetUp()]
        public void Init()
        {
            
            model = new VendingMachineModel(new VendingMachineTimer());
            controller = new VendingMachineController(model);
        }

        [TearDown()]
        public void Dispose()
        {
            model = null;
            controller = null;
        }

        [Test()]
        public void WhenCurrentStateIsChangedInModelItShouldNotifyController()
        {
            var notified = false;
            model.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "CurrentState")
                    notified = true;
            };

            model.Purchase(new Chips());
            Assert.True(notified);
        }

        [Test()]
        public void WhenTotalIsChangedInModelItShouldNotifyController()
        {
            var notified = false;
            model.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "Total")
                    notified = true;
            };

            model.InsertCoin(new Quarter());
            Assert.True(notified);
        }

        [Test()]
        public void WhenReturnedTotalIsChangedInModelItShouldNotifyController()
        {
            var notified = false;
            model.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "ReturnedTotal")
                    notified = true;
            };

            model.InsertCoin(new Quarter());
            model.ReturnCoins();
            Assert.True(notified);
        }

        [Test()]
        public void WhenTotalNotifyPropertyChangeOccursItShouldUpdateViewsTotal()
        {
            model.InsertCoin(new Quarter());
            Assert.That(controller.total_TextBox.Text.Equals(VendingMachineConstants.QUARTER_VALUE.ToString()));
        }

        [Test()]
        public void WhenReturnedTotalNotifyPropertyChangeOccursItShouldUpdateViewsReturnedTotal()
        {
            model.InsertCoin(new Quarter());
            model.ReturnCoins();
            Assert.That(controller.returnedTotal_TextBox.Text.Equals(VendingMachineConstants.QUARTER_VALUE.ToString()));
        }

        [Test()]
        public void WhenCurrentStateNotifyPropertyChangeOccursItShouldUpdateViewCurrentState()
        {
            model.Purchase(new Chips());
            Assert.That(controller.vendingMachineState_Textbox.Text.Equals(VENDING_MACHINE_STATE.PRICE_CHECK.ToString()));
        }
    }
}