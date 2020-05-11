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
            try
            {
                string jsonFile = "C:\\Orion\\Exceptions.Json";
                string rawJson = File.ReadAllText(jsonFile);
                ExpCollection result = JsonConvert.DeserializeObject<ExpCollection>(rawJson);
                int Count = result.Exps.Count;
                Exp Exps = new Exp
                {
                    Id = ++Count,
                    _Time = DateTime.Now.ToShortTimeString(),
                    _Date = DateTime.Today.ToShortDateString(),
                    _Message = ex.Message.ToString(),
                    _StackTrace = ex.StackTrace.ToString()
                };

                string serializedJson = JsonConvert.SerializeObject(Exps);
                File.WriteAllText("C:\\Orion\\", "Exceptions.Json");
            }
            catch (Exception e)
            {
                Console.WriteLine("Add Error : " + e.Message.ToString());
            }
        }
    }

    public class ExpCollection
    {
        private List<Exp> exps;
        public List<Exp> Exps { get => exps; set => exps = value; }
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

        [JsonProperty("StackTrace")]
        public string _StackTrace { get; set; }
    }
}