using System;
using System.Windows.Forms;

namespace SimpleBilling
{
    public static class Info
    {
        public static void Mes(string mes)
        {
            MessageBox.Show(mes);
        }

        public static DateTime Today()
        {
            DateTime Today = DateTime.Today;
            return Today;
        }
    }
}
