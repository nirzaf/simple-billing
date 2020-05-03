using Microsoft.OData.Edm;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace SimpleBilling
{
    public static class Info
    {
        public static void Mes(string mes)
        {
            MessageBox.Show(mes);
        }

        public static void Required()
        {
            MessageBox.Show("Please make sure you have entered all the required fields");
        }

        public static DateTime Today()
        {
            string Date = DateTime.Today.ToShortDateString();
            DateTime Today = Convert.ToDateTime(Date);
            return Today;
        }

        public static bool IsNumber(char ch, string text)
        {
            bool res = true;
            char decimalChar = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            if (ch == decimalChar && text.IndexOf(decimalChar) != -1)
            {
                res = false;
                return res;
            }

            if (!char.IsDigit(ch) && ch != decimalChar && ch != (char)Keys.Back)
                res = false;

            return res;
        }

        public static void IsDecimal(KeyPressEventArgs e, TextBox txt)
        {
            if (!IsNumber(e.KeyChar, txt.Text))
                e.Handled = true;
        }

        public static void IsInt(KeyPressEventArgs e)
        {
            if ((!char.IsDigit(e.KeyChar)) && (e.KeyChar != Convert.ToChar(Keys.Back)))
                e.Handled = true;
        }
        public static bool IsEmpty(TextBox t)
        {
            if (string.IsNullOrWhiteSpace(t.Text.Trim()))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
