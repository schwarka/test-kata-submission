namespace VendingMachineApp.src
{
    /// <summary>
    ///     Interface to represent Vending Machine products.
    /// </summary>
    public interface IProduct
    {
        /// <summary>
        ///     Amount of stock left of said product.
        /// </summary>
        int Stock { get; }

        /// <summary>
        ///     Cost of product.
        /// </summary>
        double Price { get; }

        bool Purchase();
    }
}
