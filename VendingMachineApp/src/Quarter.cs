using System;

namespace VendingMachineApp.src
{
    /// <summary>
    ///     Physical properties of U.S. Quarter.
    /// </summary>
    public class Quarter : ICoin
    {
        public double Mass => VendingMachineConstants.QUARTER_MASS;

        public double Diameter => VendingMachineConstants.QUARTER_DIAMETER;

        public double Thickness => VendingMachineConstants.QUARTER_THICKNESS;

        public override bool Equals(Object obj)
        {
            ICoin coinObj = obj as ICoin;
            if (coinObj == null)
                return false;
            else
                return coinObj.Mass == Mass && coinObj.Diameter == Diameter && coinObj.Thickness == Thickness;
        }

        public override int GetHashCode()
        {
            return this.Mass.GetHashCode();
        }
    }
}
