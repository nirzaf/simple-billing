using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SimpleBilling.Model
{
    public class PurchaseOrder : BaseEntity
    {
        [Key]
        public string OrderUniqueId { get; set; }
        public string OrderedDate { get; set; }
        public int SupplierId { get; set; }
        [DefaultValue(false)]
        public bool IsOrderCompleted { get; set; }
        [DefaultValue(false)]
        public bool IsReceived { get; set; }
    }
}
