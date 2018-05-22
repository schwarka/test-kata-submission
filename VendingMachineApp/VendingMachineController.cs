using System;
using System.ComponentModel;
using System.Windows.Forms;
using VendingMachineApp.src;

namespace VendingMachineApp
{
    /// <summary>
    ///     The View code is what lives inside the Designer portion of our Windows Form code. 
    ///     This is where the buttons, layout, labels, textboxes etc etc are all instantiatied and this
    ///     is what would traditionally be called our View. This class contains the correlated events for our button
    ///     clicks and user interaction with our Designer. While also containing our EventHandler to our models 
    ///     PropertyChangedEvents, which then updates our attached Designer/View as we want. 
    /// </summary>
    public partial class VendingMachineController : Form
    {
        IVendingMachineModel _model;
        IProduct chips, cola, candy;
        public VendingMachineController(IVendingMachineModel model)
        {
            if (model == null)
                return;
            this._model = model;
            chips = new Chips();
            cola = new Cola();
            candy = new Candy();

            InitializeComponent();
            VendingMachineController_Load(this, null);

        }

        /// <summary>
        ///     Sets up our model object in the controller. As well as assigning our event handler
        ///     for the models PropertyChangedEvents.
        /// </summary>
        private void VendingMachineController_Load(object sender, System.EventArgs e)
        {
            if (_model == null)
                return;

            _model.PropertyChanged += new PropertyChangedEventHandler(_model_PropertyChanged);
            _model_PropertyChanged(this, null);

            foreach (var property in typeof(VendingMachineModel).GetProperties())
                _model_PropertyChanged(this, new PropertyChangedEventArgs(property.Name));
        }

        /// <summary>
        ///     Event handler that is called whenever PropertyChangedEvent occurs in our correlated 
        ///     VendingMachineModel.
        /// </summary>
        public void _model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // Check if e is null, if it is set property to string.Empty
            var property = e?.PropertyName ?? string.Empty;
            MethodInvoker updateDelegate = delegate ()
            {
                switch (property)
                {
                    case nameof(_model.CurrentState):
                        this.vendingMachineState_Textbox.Text = _model.CurrentState.ToString();
                        break;
                    case nameof(_model.Total):
                        this.total_TextBox.Text = _model.Total.ToString();
                        break;
                    case nameof(_model.ReturnedTotal):
                        this.returnedTotal_TextBox.Text = _model.ReturnedTotal.ToString();
                        break;
                }
            };

            if (this.InvokeRequired)
                this.Invoke(updateDelegate);
            else updateDelegate();
        }


        public void insertQuarter_button_Click(object sender, EventArgs e)
        {
            if (_model != null)
             _model.InsertCoin(new Quarter());
        }

        public void insertDime_button_Click(object sender, EventArgs e)
        {
            if (_model != null)
                _model.InsertCoin(new Dime());
        }

        public void insertNickel_button_Click(object sender, EventArgs e)
        {
            if (_model != null)
                _model.InsertCoin(new Nickel());
        }

        public void insertPenny_button_Click(object sender, EventArgs e)
        {
            if (_model != null)
                _model.InsertCoin(new Penny());
        }

        public void returnCoins_Button_Click(object sender, EventArgs e)
        {
            if (_model != null)
                _model.ReturnCoins();
        }

        public void buyChips_Button_Click(object sender, EventArgs e)
        {
            if (_model != null && _model.Purchase(chips))
            {
                chipsStock_Label.Text = chipsStock_Label.Text.Substring(0, chipsStock_Label.Text.Length - 1) + chips.Stock;
            }
        }

        public void buyCola_Button_Click(object sender, EventArgs e)
        {
            if (_model != null && _model.Purchase(cola))
            {
                colaStock_Label.Text = colaStock_Label.Text.Substring(0, colaStock_Label.Text.Length - 1) + cola.Stock;
            }
        }

        public void buyCandy_Button_Click(object sender, EventArgs e)
        {
            if (_model != null && _model.Purchase(candy))
            {
                candyStock_Label.Text = candyStock_Label.Text.Substring(0, candyStock_Label.Text.Length - 1) + candy.Stock;
            }
        }
    }
}
