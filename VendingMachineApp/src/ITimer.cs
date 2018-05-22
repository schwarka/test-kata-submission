using System.Timers;

namespace VendingMachineApp.src
{
    public interface ITimer
    {
        event ElapsedEventHandler Elapsed;

        double Interval { get; set; }
        bool AutoReset { get; set; }

        void Dispose();

        void Start();

        void Stop();
    }
}
