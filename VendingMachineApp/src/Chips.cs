namespace VendingMachineApp.src
{
    /// <summary>
    ///     Chips product that can be purchased inside of our Vending Machine App
    /// </summary>
    public class Chips : IProduct
    {
        /// <summary>
        ///     Count of how many Chips have been purchased.
        /// </summary>
        private int purchased = 0;

        /// <summary>
        ///     Read-only property which returns how many Chips remain in stock.
        /// </summary>
        public int Stock => (VendingMachineConstants.COLA_STOCK - purchased);

        /// <summary>
        ///     Read-only property which returns the price of a bag of Chips.
        /// </summary>
        public double Price => VendingMachineConstants.CHIPS_PRICE;

        /// <summary>
        ///     Called whenever a bag of Chips is purchased out of the machine.
        /// </summary>
        public bool Purchase()
        {
            if (Stock == 0)
                return false;

            purchased++;
            return true;
        }
    }
}
