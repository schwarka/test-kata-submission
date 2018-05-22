namespace VendingMachineApp.src
{
    /// <summary>
    ///     Collection of constants used through the Vending Machine App
    /// </summary>
    public class VendingMachineConstants
    {
        /// <summary>
        ///     Coin Mass Constants
        /// </summary>
        public const double QUARTER_MASS = 5.67;
        public const double DIME_MASS = 2.268;
        public const double NICKEL_MASS = 5.0;
        public const double PENNY_MASS = 2.5;

        /// <summary>
        ///     Coin Diameter Constants
        /// </summary>
        public const double QUARTER_DIAMETER = 24.26;
        public const double DIME_DIAMETER = 17.91;
        public const double NICKEL_DIAMETER = 21.21;
        public const double PENNY_DIAMETER = 19.05;

        /// <summary>
        ///     Coin Thickness Constants
        /// </summary>
        public const double QUARTER_THICKNESS = 1.75;
        public const double DIME_THICKNESS = 1.35;
        public const double NICKEL_THICKNESS = 1.95;
        public const double PENNY_THICKNESS = 1.52;

        /// <summary>
        ///     Amount of product in Vending Machine.
        /// </summary>
        public const int COLA_STOCK = 3;
        public const int CHIPS_STOCK = 3;
        public const int CANDY_STOCK = 3;

        /// <summary>
        ///     Cost of product in dollars ($).
        /// </summary>
        public const double COLA_PRICE = 1;
        public const double CHIPS_PRICE = 0.50;
        public const double CANDY_PRICE = 0.65;

        /// <summary>
        ///     Currency values of all possible Coins in cents.
        /// </summary>
        public const double QUARTER_VALUE = 0.25;
        public const double DIME_VALUE = 0.10;
        public const double NICKEL_VALUE = 0.05;
        public const double PENNY_VALUE = 0.01;

        /// <summary>
        ///     Time interval used to setup Timer.
        /// </summary>
        public const int TIMER_INTERVAL = 2000;
    }
}
