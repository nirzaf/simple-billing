using iText.Layout.Element;
using SimpleBilling.Model;
using System;
using System.Data.Entity;
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
            try
            {
                if (DNumber.StartsWith("0"))
                {
                    DNumber = DNumber.Remove(0, 1);
                }
                if (!DNumber.StartsWith("94"))
                {
                    DNumber = "94" + DNumber;
                }

                try
                {
                    string request = "https://bulksms2.etisalat.lk/sendsmsmultimask.php?";
                    var postData = "USER=" + HttpUtility.UrlPathEncode(Username) + "&PWD=" + HttpUtility.UrlPathEncode(Password) + "&MASK=" + HttpUtility.UrlPathEncode(CallerId) + "&NUM=" + HttpUtility.UrlPathEncode(DNumber) + "&MSG=" + HttpUtility.UrlDecode(Message);

                    using (var web = new WebClient())
                    {
                        Debug.WriteLine(request + postData);
                        string result = web.DownloadString(request + postData);
                        using (BillingContext db = new BillingContext())
                        {
                            SMSLog log = new SMSLog
                            {
                                CreatedDate = DateTime.Today,
                                LogKey = Rand.RandomString(15),
                                LogMessage = Message,
                                Log = result,
                                Number = DNumber
                            };
                            if (db.Entry(log).State == EntityState.Detached)
                                db.Set<SMSLog>().Attach(log);
                            db.Entry(log).State = EntityState.Added;
                            db.SaveChanges();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Info.Mes(ex.Message);
                    return;
                }
            }
            catch (Exception ex)
            {
                Info.Mes(ex.Message);
            }            
        }
    }
}
