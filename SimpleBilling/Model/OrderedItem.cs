using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleBilling.Model
{
    public class OrderedItem : BaseEntity
    {
        [Key]
        [Column(Order = 1)]
        public string ItemCode { get; set; }
        [Key]
        [Column(Order = 2)]
        public string OrderId { get; set; }
        public int Quantity { get; set; }
        [MaxLength(30)]
        public string UnitType { get; set; }
        [DefaultValue(false)]
        public bool IsReceived { get; set; }
    }
}
