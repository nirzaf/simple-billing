using Microsoft.OData.Edm;
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
            string Date = DateTime.Today.ToShortDateString();
            DateTime Today = Convert.ToDateTime(Date);
            return Today;
        }
    }
}
