using System.ComponentModel.DataAnnotations;

namespace SimpleBilling.Model
{
    public class SMSLog : BaseEntity
    {
        [Key]
        public string LogKey { get; set; }
        public string LogMessage { get; set; }
        public string Number { get; set; }
        public string Log { get; set; }
    }
}
