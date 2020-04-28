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
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new ManageGRN(string.Empty));
            Application.Run(new POS());
        }
    }
}
