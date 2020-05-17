using System.ComponentModel.DataAnnotations;

namespace SimpleBilling.Model
{
    public class OrderedItem : BaseEntity
    {
        [Key]
        public string ItemCode { get; set; }
        public int Quantity { get; set; }
        [MaxLength(30)]
        public string UnitType { get; set; }
        public bool IsReceived { get; set; }
        public int PurchaseOrderId { get; set; }
    }
}
