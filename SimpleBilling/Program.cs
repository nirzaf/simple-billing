using SimpleBilling.MasterForms;
using System;
using System.Windows.Forms;

namespace SimpleBilling
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Main());
            Application.Run(new ManageCheques());
            //Application.Run(new ManageBanks());
            //Application.Run(new ManageStock());
            //Application.Run(new ManageGRN(string.Empty));
            //Application.Run(new POS(string.Empty));
            //Application.Run(new BusinessInfo());
            //Application.Run(new ManageVehicles());
            //Application.Run(new ManageCategory());
            //Application.Run(new ManageItems());
            //Application.Run(new ManageVehicles());
            //Application.Run(new ManageShelves());
            //Application.Run(new LoadReceipt());
        }
    }
}