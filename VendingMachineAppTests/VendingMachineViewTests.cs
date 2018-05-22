using NUnit.Framework;
using VendingMachineApp.src;
using Moq;

namespace VendingMachineApp.Tests
{
    [TestFixture()]
    public class VendingMachineViewTests
    {
        private Mock<IVendingMachineModel> mockModel;
        private IVendingMachineModel model;
        private VendingMachineController controller;

        [SetUp()]
        public void Init()
        {
            mockModel = new Mock<IVendingMachineModel>();
            model = mockModel.Object;
            controller = new VendingMachineController(model);
        }

        [TearDown()]
        public void Dispose()
        {
            controller = null;
            model = null;
            mockModel = null;
        }

        [Test()]
        public void WhenQuarterButtonIsPressedItShouldCallInsertCoinsMethodWithQuarterAsParameter()
        {
            controller.insertQuarter_button_Click(this, null);
            mockModel.Verify(x => x.InsertCoin(It.Is<ICoin>(n => 
                n.Diameter == VendingMachineConstants.QUARTER_DIAMETER && 
                n.Mass == VendingMachineConstants.QUARTER_MASS && 
                n.Thickness == VendingMachineConstants.QUARTER_THICKNESS)), Times.Once);
        }

        [Test()]
        public void WhenDimeButtonIsPressedItShouldCallInsertCoinsMethodWithDimeAsParameter()
        {
            controller.insertDime_button_Click(this, null);
            mockModel.Verify(x => x.InsertCoin(It.Is<ICoin>(n =>
                n.Diameter == VendingMachineConstants.DIME_DIAMETER &&
                n.Mass == VendingMachineConstants.DIME_MASS &&
                n.Thickness == VendingMachineConstants.DIME_THICKNESS)), Times.Once);
        }

        [Test()]
        public void WhenNickelButtonIsPressedItShouldCallInsertCoinsMethodWithNickelAsParameter()
        {
            controller.insertNickel_button_Click(this, null);
            mockModel.Verify(x => x.InsertCoin(It.Is<ICoin>(n =>
                n.Diameter == VendingMachineConstants.NICKEL_DIAMETER &&
                n.Mass == VendingMachineConstants.NICKEL_MASS &&
                n.Thickness == VendingMachineConstants.NICKEL_THICKNESS)), Times.Once);
        }

        [Test()]
        public void WhenPennyButtonIsPressedItShouldCallInsertCoinsMethodWithPennyAsParameter()
        {
            controller.insertPenny_button_Click(this, null);
            mockModel.Verify(x => x.InsertCoin(It.Is<ICoin>(n =>
                n.Diameter == VendingMachineConstants.PENNY_DIAMETER &&
                n.Mass == VendingMachineConstants.PENNY_MASS &&
                n.Thickness == VendingMachineConstants.PENNY_THICKNESS)), Times.Once);
        }

        [Test()]
        public void WhenChipsButtonIsPressedItShouldCallPurchaseMethodWithChipsAsParameter()
        {
            Chips chips = new Chips();
            controller.buyChips_Button_Click(this, null);
            mockModel.Verify(x => x.Purchase(It.Is<IProduct>(n =>
                n.GetType() == chips.GetType())), Times.Once);
        }

        [Test()]
        public void WhenColaButtonIsPressedItShouldCallPurchaseMethodWithColaAsParameter()
        {
            Cola cola = new Cola();
            controller.buyCola_Button_Click(this, null);
            mockModel.Verify(x => x.Purchase(It.Is<IProduct>(n =>
                n.GetType() == cola.GetType())), Times.Once);
        }

        [Test()]
        public void WhenCandyButtonIsPressedItShouldCallPurchaseMethodWithCandyAsParameter()
        {
            Candy candy = new Candy();
            controller.buyCandy_Button_Click(this, null);
            mockModel.Verify(x => x.Purchase(It.Is<IProduct>(n =>
                n.GetType() == candy.GetType())), Times.Once);
        }

        [Test()]
        public void WhenReturnCoinsButtonIsPressedItShouldCallReturnCoinsMethod()
        {
            controller.returnCoins_Button_Click(this, null);
            mockModel.Verify(x => x.ReturnCoins(), Times.Once);
        }
    }
}