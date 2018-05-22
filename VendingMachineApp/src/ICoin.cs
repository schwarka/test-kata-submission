namespace VendingMachineApp.src
{
    /// <summary>
    ///     Represents a physical coin via three physical read-only properties.
    /// </summary>
    public interface ICoin
    {
        /// <summary>
        ///     Mass of coin in grams (g).
        /// </summary>
        double Mass { get; }

        /// <summary>
        ///     Diameter of coin in millimeters (mm).
        /// </summary>
        double Diameter { get; }

        /// <summary>
        ///     Thickness of coin in millimeters (mm).
        /// </summary>
        double Thickness { get; }


    }
}
