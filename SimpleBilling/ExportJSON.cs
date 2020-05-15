using Newtonsoft.Json;
using SimpleBilling.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SimpleBilling
{
    public static class ExportJSON
    {
        public static void Add(Exception ex)
        {
            try
            {
                using (BillingContext db = new BillingContext())
                {
                    var data = db.Settings.FirstOrDefault(c => c.UserId == 1);
                    string path = data.ExceptionPath;
                    string fileName = path + "exception.json";
                    string rawJson;
                    if (!File.Exists(fileName))
                    {
                        File.Create(fileName);
                    }

                    rawJson = File.ReadAllText(fileName);
                    var ec = JsonConvert.DeserializeObject<ExpCollection>(rawJson);

                    if (ec != null)
                    {
                        int Count = ec.Exceptions.Count;
                        Exp Exps = new Exp
                        {
                            Id = ++Count,
                            Time = DateTime.Now.ToShortTimeString(),
                            Date = DateTime.Today.ToShortDateString(),
                            Message = ex.Message.ToString(),
                            StackTrace = ex.StackTrace.ToString()
                        };
                        ec.Exceptions.Add(Exps);
                        string serializedJson = JsonConvert.SerializeObject(ec, Formatting.Indented);
                        File.WriteAllText(path, serializedJson);
                    }
                    else
                    {
                        ExpCollection exp = new ExpCollection
                        {
                            Exceptions = new List<Exp>()
                        };
                        Exp Exps = new Exp
                        {
                            Id = 1,
                            Time = DateTime.Now.ToShortTimeString(),
                            Date = DateTime.Today.ToShortDateString(),
                            Message = ex.Message.ToString(),
                            StackTrace = ex.StackTrace.ToString()
                        };
                        exp.Exceptions.Add(Exps);
                        string serializedJson = JsonConvert.SerializeObject(exp, Formatting.Indented);
                        File.WriteAllText(path, serializedJson);
                    }
                }
            }
            catch (Exception e)
            {
                Add(e);
            }
            finally
            {
                Info.Mes(ex.Message);
            }
        }
    }

    public class ExpCollection
    {
        public List<Exp> Exceptions { get; set; }
    }

    public class Exp
    {
        [JsonProperty]
        public int Id { get; set; }

        [JsonProperty]
        public string Time { get; set; }

        [JsonProperty]
        public string Date { get; set; }

        [JsonProperty]
        public string Message { get; set; }

        [JsonProperty]
        public string StackTrace { get; set; }
    }
}