using System;

namespace VendingMachineApp.src
{
    /// <summary>
    ///     Physical properties of U.S. Penny.
    /// </summary>
    public class Penny : ICoin
    {
        public double Mass => VendingMachineConstants.PENNY_MASS;

        public double Diameter => VendingMachineConstants.PENNY_DIAMETER;

        public double Thickness => VendingMachineConstants.PENNY_THICKNESS;

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
