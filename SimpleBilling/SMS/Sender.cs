using System.Diagnostics;
using System.Net;
using System.Web;
using System.Windows.Forms;

namespace SimpleBilling.SMS
{
    public static class Sender
    {
        private static string username = "New_city";
        private static string password = "NCI@123";
        private static string callerId = "CAR WEST";

        public static void SendWebRequest(string DNumber, string Message)
        {
            string request = "https://bulksms2.etisalat.lk/sendsmsmultimask.php?";
            var postData = "USER=" + HttpUtility.UrlPathEncode(username) + "&PWD=" + HttpUtility.UrlPathEncode(password) + "&MASK=" + HttpUtility.UrlPathEncode(callerId) + "&NUM=" + HttpUtility.UrlPathEncode(DNumber) + "&MSG=" + HttpUtility.UrlDecode(Message);

            using (var web = new WebClient())
            {
                Debug.WriteLine(request + postData);
                string result = web.DownloadString(request + postData);
                MessageBox.Show(result);
            }
        }

    }
}
