namespace VendingMachineApp.src
{
    /// <summary>
    ///     Cola product that can be purchased inside of our Vending Machine App
    /// </summary>
    public class Cola : IProduct
    {
        /// <summary>
        ///     Count of how many Colas have been purchased.
        /// </summary>
        private int purchased = 0;

        /// <summary>
        ///     Read-only property which returns how many Cola remain in stock.
        /// </summary>
        public int Stock => (VendingMachineConstants.COLA_STOCK - purchased);

        /// <summary>
        ///     Read-only property which returns the price of a Cola.
        /// </summary>
        public double Price => VendingMachineConstants.COLA_PRICE;

        /// <summary>
        ///     Called whenever a Cola is purchased out of the machine.
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
