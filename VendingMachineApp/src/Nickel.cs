using System;

namespace VendingMachineApp.src
{
    /// <summary>
    ///     Physical properties of U.S. Nickel.
    /// </summary>
    public class Nickel : ICoin
    {
        public double Mass => VendingMachineConstants.NICKEL_MASS;

        public double Diameter => VendingMachineConstants.NICKEL_DIAMETER;

        public double Thickness => VendingMachineConstants.NICKEL_THICKNESS;

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
