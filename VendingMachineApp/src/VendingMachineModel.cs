using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace VendingMachineApp.src
{
    /// <summary>
    ///     Performs and handles all calculations and data manipulation that is needed for
    ///     the Vending Machine front-end view.
    /// </summary>
    public class VendingMachineModel : IVendingMachineModel
    {
        private List<ICoin> _machineCoins, _insertedCoins, _returnedCoins;
        private Quarter quarter = new Quarter();
        private Dime dime = new Dime();
        private Nickel nickel = new Nickel();
        private Penny penny = new Penny();
        private VENDING_MACHINE_STATE _currentState;
        private double _total, _returnedTotal;
        private static ITimer _timer;

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        ///     Constructor for IVendingMachineModel which requires an ITimer object as a parameter.
        /// </summary>
        /// <param name="vendingMachineTimer">Instance of ITimer</param>
        public VendingMachineModel(ITimer vendingMachineTimer)
        {
            /* 
             *  Initialize all lists of coins within machine.
             *  For purposes of this project we will start the vending machine
             *  off with 30c of coins to make change out of. This way we don't always start
             *  in a state that requires exact change from the customer.
             */
            _machineCoins = new List<ICoin> { dime, dime, nickel, nickel };
            _insertedCoins = new List<ICoin>();
            _returnedCoins = new List<ICoin>();

            if (IsExactChangeNeeded())
                CurrentState = VENDING_MACHINE_STATE.EXACT_CHANGE_ONLY;
            else
                CurrentState = VENDING_MACHINE_STATE.INSERT_COINS;

            _total = 0;
            _returnedTotal = 0;

            //  Initialize Timer to keep the currentStatus up-to-date.
            _timer = vendingMachineTimer;
            _timer.Elapsed += TimedOut;
        }

        /// <summary>
        ///     Keeps track of the current State of the Vending Machine. There will be
        ///     a timer that will need to call the private set on a predetermined timer.
        /// </summary>
        public VENDING_MACHINE_STATE CurrentState
        {
            get { return _currentState; }
            set
            {
                if (value.Equals(_currentState))
                    return;

                _currentState = value;
                _timer.Start();
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        ///     Internal vending machine timer which extends System.Timer.
        /// </summary>
        public ITimer Timer
        {
            get { return _timer; }
        }
        /// <summary>
        ///     List of all coins currently retained inside the Vending Machine.
        /// </summary>
        public List<ICoin> MachineCoins
        {
            get { return new List<ICoin>(_machineCoins); }
        }

        /// <summary>
        ///     List of all coins inserted by a customer.
        /// </summary>
        public List<ICoin> InsertedCoins
        {
            get { return new List<ICoin>(_insertedCoins); }
        }

        /// <summary>
        ///     List of coins sent to coin return.
        /// </summary>
        public List<ICoin> ReturnedCoins
        {
            get { return new List<ICoin>(_returnedCoins); }
        }

        /// <summary>
        ///     Customer's running total of inserted coins.
        /// </summary>
        public double Total
        {
            get { return _total; }
            private set
            {
                _total = Math.Round(value, 2, MidpointRounding.AwayFromZero);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        ///     Total change sitting in coin return.
        /// </summary>
        public double ReturnedTotal
        {
            get { return _returnedTotal; }
            private set
            {
                _returnedTotal = Math.Round(value, 2, MidpointRounding.AwayFromZero);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        ///     Called when a coin is inserted into the Vending Machine. This can identify if the coin
        ///     inserted is acceptable and if so catalogs the coin inserted and adds its value to customer Total.
        /// </summary>
        /// <param name="coin"> Inserted Coin </param>
        public void InsertCoin(ICoin coin)
        {
            //  Check the inserted coins Mass, Diameter, and Thickness to identify it.
            if (coin.Mass == VendingMachineConstants.QUARTER_MASS && coin.Diameter == VendingMachineConstants.QUARTER_DIAMETER 
                && coin.Thickness == VendingMachineConstants.QUARTER_THICKNESS)
            {
                Total = _total + VendingMachineConstants.QUARTER_VALUE;
                _insertedCoins.Add(coin);
            }
            else if (coin.Mass == VendingMachineConstants.DIME_MASS && coin.Diameter == VendingMachineConstants.DIME_DIAMETER
                && coin.Thickness == VendingMachineConstants.DIME_THICKNESS)
            {
                Total = _total + VendingMachineConstants.DIME_VALUE;
                _insertedCoins.Add(coin);
            }
            else if (coin.Mass == VendingMachineConstants.NICKEL_MASS && coin.Diameter == VendingMachineConstants.NICKEL_DIAMETER
                && coin.Thickness == VendingMachineConstants.NICKEL_THICKNESS)
            {
                Total = _total + VendingMachineConstants.NICKEL_VALUE;
                _insertedCoins.Add(coin);
            }
            //  If a Penny was inserted do not add value to Total. Instead send penny to coin return.
            else if (coin.Mass == VendingMachineConstants.PENNY_MASS && coin.Diameter == VendingMachineConstants.PENNY_DIAMETER
                && coin.Thickness == VendingMachineConstants.PENNY_THICKNESS)
            {
                ReturnedTotal = _returnedTotal + VendingMachineConstants.PENNY_VALUE;
                _returnedCoins.Add(coin);
                return;
            }
            CurrentState = VENDING_MACHINE_STATE.DISPLAY_TOTAL;
        }

        /// <summary>
        ///     Send all currently Inserted Coins to Returned Coins.
        /// </summary>
        public void ReturnCoins()
        {
            _returnedCoins.AddRange(_insertedCoins);
            _insertedCoins.Clear();

            //  Add Total to ReturnedTotal and then reset Total;
            ReturnedTotal = _returnedTotal + Total;
            Total = 0;
        }

        /// <summary>
        ///     Attempt to purchase a product out of Vending Machine with
        ///     current Total.
        /// </summary>
        /// <param name="product"> Type of product selected </param>
        /// <returns></returns>
        public bool Purchase(IProduct product)
        {
            //  Check if requested product to purchase still has stock.
            if (product.Stock < 1)
            {
                CurrentState = VENDING_MACHINE_STATE.SOLD_OUT;
                return false;
            }

            //  If not enough money was inserted yet give user product price check, and return false.
            if (Total < product.Price)
            {
                CurrentState = VENDING_MACHINE_STATE.PRICE_CHECK;
                return false;
            }

            //  If exact change is needed and not met than return coins and deny purchase.
            if (IsExactChangeNeeded() && Total != product.Price)
            {
                ReturnCoins();
                CurrentState = VENDING_MACHINE_STATE.EXACT_CHANGE_ONLY;
                return false;
            }

            //  If we made it this far then we are good to purchase our product.
            product.Purchase();
            CurrentState = VENDING_MACHINE_STATE.PURCHASE_COMPLETED;

            //  Move all inserted coins to machine coins.
            _machineCoins.AddRange(_insertedCoins);
            _insertedCoins.Clear();

            //  Adjust total after purchase.
            Total = _total - product.Price;

            //  Make change is exact change was not given.
            if (Total != 0)
                MakeChange(Total);

            return true;

        }

        /// <summary>
        ///     Make change based on the coins inside the machine and the amount of
        ///     change that needs to be returned to the customer after a purchase is complete.
        /// </summary>
        /// <param name="change"> Value of change to be returned to customer </param>
        private void MakeChange(double change)
        {
            /*
             *  Make change based on the coins inside the machine and the outstanding amount of change to
             *  be returned.
             */
            while (change != 0)
            {
                if ((change / VendingMachineConstants.QUARTER_VALUE >= 1) && _machineCoins.Contains(quarter))
                {
                    change = Math.Round(change - VendingMachineConstants.QUARTER_VALUE, 2, MidpointRounding.AwayFromZero);
                    _machineCoins.Remove(quarter);
                    _returnedCoins.Add(quarter);
                    ReturnedTotal = _returnedTotal + VendingMachineConstants.QUARTER_VALUE;
                } 
                else if ((change / VendingMachineConstants.DIME_VALUE >= 1) && _machineCoins.Contains(dime))
                {
                    change = Math.Round(change - VendingMachineConstants.DIME_VALUE, 2, MidpointRounding.AwayFromZero);
                    _machineCoins.Remove(dime);
                    _returnedCoins.Add(dime);
                    ReturnedTotal = _returnedTotal + VendingMachineConstants.DIME_VALUE;
                }
                else if ((change / VendingMachineConstants.NICKEL_VALUE >= 1) && _machineCoins.Contains(nickel))
                {
                    change = Math.Round(change - VendingMachineConstants.NICKEL_VALUE, 2, MidpointRounding.AwayFromZero);
                    _machineCoins.Remove(nickel);
                    _returnedCoins.Add(nickel);
                    ReturnedTotal = _returnedTotal + VendingMachineConstants.NICKEL_VALUE;
                }
            }

            //  Reset total after change has been returned.
            Total = 0;
        }

        /// <summary>
        ///     Checks if coins that exists inside of the machine are currently enough to make change
        ///     for any possible customer purchase.
        /// </summary>
        /// <returns> Returns whether or not exact chance is currently needed. </returns>
        private bool IsExactChangeNeeded()
        {
            bool exactChange = true;
            List<ICoin> availableChange = new List<ICoin>(_machineCoins);

            //      Essentially the only values that we need to make change for are 5c, 10c, 15c, 20c. Everything
            //  25c and above is something that we can assume that the customer has put in and we can just return
            //  the extra coins that they put in. 
            //
            //      The 5c, 10c, 15c, 20c, states are actually all because a customer could put in a quarter when
            //  which we as the machine would have to break its value down into smaller changeable coins. Thus as
            //  long as the machine has atleast 2 dimes and 1 nickel we can fulfill all changeable states that might
            //  occur with a quarter being broken down.
            exactChange = !(availableChange.Remove(dime) && availableChange.Remove(dime) && availableChange.Remove(nickel));

            return exactChange;
        }

        /// <summary>
        ///     Emptys the list of internal machine coins and updates current state to Exact Change Only.
        ///     
        ///     This method is mainly used as a helper method for testing but it could also be practical if
        ///     lets say the mechanic wanted to beable to pull all the coins out of the machine without opening
        ///     our vending machine physically.
        /// </summary>
        public void EmptyMachineCoins()
        {
            _machineCoins = new List<ICoin>();
            CurrentState = VENDING_MACHINE_STATE.EXACT_CHANGE_ONLY;
        }

        /// <summary>
        ///     Event that is raised by a 2-second timer whenever the state is changed to a new state.
        /// </summary>
        public void TimedOut(object obj, EventArgs e)
        {
            if (Total > 0)
            {
                CurrentState = VENDING_MACHINE_STATE.DISPLAY_TOTAL;
            }
            else
            {
                if (IsExactChangeNeeded())
                    CurrentState = VENDING_MACHINE_STATE.EXACT_CHANGE_ONLY;
                else
                    CurrentState = VENDING_MACHINE_STATE.INSERT_COINS;
            }
        }
    }
}
