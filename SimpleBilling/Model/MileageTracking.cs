using System.ComponentModel.DataAnnotations;

namespace SimpleBilling.Model
{
    public class MileageTracking : BaseEntity
    {
        [Key]
        public int MileageId { get; set; }

        public int Mileage { get; set; }
        public int NextServiceDue { get; set; }
        public string VehicleNo { get; set; }
        public string ReceiptNo { get; set; }
    }
}