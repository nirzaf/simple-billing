using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SimpleBilling
{
    public static class ExportJSON
    {
        public static void Add(Exception ex)
        {
            string jsonFile = "C:\\Orion\\Exceptions.Json";
            try
            {
                Exp e = new Exp();
            }
            catch (Exception e)
            {
                Console.WriteLine("Add Error : " + e.Message.ToString());
            }
        }
    }

    public class Exp
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Time")]
        public string _Time { get; set; }

        [JsonProperty("Date")]
        public string _Date { get; set; }

        [JsonProperty("Message")]
        public string _Message { get; set; }

        public void Message(Exception ex)
        {
            _Message = ex.Message.ToString();
        }

        public void Time()
        {
            _Time = DateTime.Now.ToShortTimeString();
        }

        public void Date()
        {
            _Date = DateTime.Today.ToShortDateString();
        }
    }
}