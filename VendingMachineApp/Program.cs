using System;
using System.Windows.Forms;
using VendingMachineApp.src;

namespace VendingMachineApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            VendingMachineTimer timer = new VendingMachineTimer();
            //  Initialize model-view and pass into controller constructor to setup MVC.
            VendingMachineModel model = new VendingMachineModel(timer);
            VendingMachineController controller = new VendingMachineController(model);

            Application.EnableVisualStyles();
            Run(controller);
           
        }

        private static void Run(VendingMachineController controller)
        {
            Application.Run(controller);
        }
    }
}
