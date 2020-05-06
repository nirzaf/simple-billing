using System.ComponentModel.DataAnnotations;

namespace SimpleBilling.Model
{
    public class MileageTracking
    {
        [Key]
        public int MileageId { get; set; }

        public int Mileage { get; set; }
        public virtual Vehicle Vehicles { get; set; }
        public virtual string ReceiptNo { get; set; }
    }
}