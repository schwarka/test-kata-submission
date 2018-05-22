using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace VendingMachineApp.src
{
    public interface IVendingMachineModel : INotifyPropertyChanged
    {
        /// <summary>
        ///     Keeps track of the current State of the Vending Machine. There will be
        ///     a timer that will need to call the private set on a predetermined timer.
        /// </summary>
        VENDING_MACHINE_STATE CurrentState { get; }

        ITimer Timer { get; }
        /// <summary>
        ///     Log of all coins currently retained inside the Vending Machine.
        /// </summary>
        List<ICoin> MachineCoins { get; }

        /// <summary>
        ///     Log of all coins inserted by a customer.
        /// </summary>
        List<ICoin> InsertedCoins { get; }

        /// <summary>
        ///     List of coins sent to coin return.
        /// </summary>
        List<ICoin> ReturnedCoins { get; }

        /// <summary>
        ///     Customer's running total of inserted coins.
        /// </summary>
        double Total { get; }

        /// <summary>
        ///     Total change sitting in coin return.
        /// </summary>
        double ReturnedTotal { get; }

        /// <summary>
        ///     Called when a coin is inserted into the Vending Machine. This can identify if the coin
        ///     inserted is acceptable and if so catalogs the coin inserted and adds its value to customer Total.
        /// </summary>
        /// <param name="coin"> Inserted Coin </param>
        void InsertCoin(ICoin coin);

        /// <summary>
        ///     Attempt to purchase a product out of Vending Machine with
        ///     current Total.
        /// </summary>
        /// <param name="product"> Type of product selected </param>
        /// <returns> True if purchase is successful, False otherwise. </returns>
        bool Purchase(IProduct product);

        /// <summary>
        ///     Send all currently Inserted Coins to Returned Coins.
        /// </summary>
        void ReturnCoins();

        /// <summary>
        ///     Event that is raised whenever our VendingMachineTimer Elapses its predetermined interval.
        /// </summary>
        void TimedOut(object obj, EventArgs e);
    }
}
