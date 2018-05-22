﻿using System;

namespace VendingMachineApp.src
{
    /// <summary>
    ///     Physical properties of U.S. Dime.
    /// </summary>
    public class Dime : ICoin
    {
        public double Mass => VendingMachineConstants.DIME_MASS;

        public double Diameter => VendingMachineConstants.DIME_DIAMETER;

        public double Thickness => VendingMachineConstants.DIME_THICKNESS;

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
