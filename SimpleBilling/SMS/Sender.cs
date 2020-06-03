using System.Diagnostics;
using System.Net;
using System.Web;
using System.Windows.Forms;

namespace SimpleBilling.SMS
{
    public static class Sender
    {
        private static string Username = "New_city";
        private static string Password = "NCI@123";
        private static string CallerId = "CAR WEST";
        public static void Send(string DNumber, string Message)
        {
            if (DNumber.StartsWith("0"))
            {
                DNumber = DNumber.Remove(0, 1);
            }
            if (!DNumber.StartsWith("94"))
            {
                DNumber = "94" + DNumber;
            }
            string request = "https://bulksms2.etisalat.lk/sendsmsmultimask.php?";
            var postData = "USER=" + HttpUtility.UrlPathEncode(Username) + "&PWD=" + HttpUtility.UrlPathEncode(Password) + "&MASK=" + HttpUtility.UrlPathEncode(CallerId) + "&NUM=" + HttpUtility.UrlPathEncode(DNumber) + "&MSG=" + HttpUtility.UrlDecode(Message);

            using (var web = new WebClient())
            {
                Debug.WriteLine(request + postData);
                string result = web.DownloadString(request + postData);
                MessageBox.Show(result);
            }
        }
    }
}
