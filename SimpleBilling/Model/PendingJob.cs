using System.ComponentModel.DataAnnotations;

namespace SimpleBilling.Model
{
    public class PendingJob : BaseEntity
    {
        [Key]
        public string ReceiptNo { get; set; }
        [MaxLength(30)]
        public string VehicleNumber { get; set; }
        [MaxLength(30)]
        public string Date { get; set; }
    }
}
