using System;
using System.Timers;

namespace VendingMachineApp.src
{
    /// <summary>
    ///     Used as an internal timer inside of our VendingMachine so that when purchase is completed
    ///     or possibly is taking to long it will reset its state back.
    /// </summary>
    public class VendingMachineTimer : Timer, ITimer
    {
        public VendingMachineTimer() : base()
        {
            this.Interval = VendingMachineConstants.TIMER_INTERVAL;
            this.AutoReset = false;
        }
    }
}
