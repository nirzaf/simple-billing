using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SimpleBilling.Model
{
    public class PurchaseOrder : BaseEntity
    {
        [Key]
        public int PurchaseOrderId { get; set; }
        public string Date { get; set; }
        [DefaultValue(false)]
        public bool IsReceived { get; set; }
    }
}
