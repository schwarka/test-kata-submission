namespace VendingMachineApp.src
{
    /// <summary>
    ///     Candy product that can be purchased inside of our Vending Machine App
    /// </summary>
    public class Candy : IProduct
    {
        /// <summary>
        ///     Count of how many Candies have been purchased.
        /// </summary>
        private int purchased = 0;

        /// <summary>
        ///     Read-only property which returns how many Candies remain in stock.
        /// </summary>
        public int Stock => (VendingMachineConstants.COLA_STOCK - purchased);

        /// <summary>
        ///     Read-only property which returns the price of Candy.
        /// </summary>
        public double Price => VendingMachineConstants.CANDY_PRICE;

        /// <summary>
        ///     Called whenever Candy is purchased out of the machine.
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
