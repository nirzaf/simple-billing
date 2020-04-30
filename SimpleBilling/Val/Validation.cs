using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SimpleBilling.Val
{
    public static class Validation
    {
        public static void TxtBox(object sender, KeyPressEventArgs e, TextBox textBox)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }

            if (Regex.IsMatch(textBox.Text, @"\.\d\d"))
            {
                e.Handled = true;
            }
        }
    }
}
