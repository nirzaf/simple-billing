using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleBilling.Model
{
    public class ReceiptBody : BaseEntity
    {
        [Key]
        [Column(Order = 1)]
        public string ReceiptNo { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ProductId { get; set; }

        [Required]
        public float UnitPrice { get; set; }

        [Required]
        public int Quantity { get; set; }

        [DefaultValue(0)]
        public float Discount { get; set; }

        public float SubTotal { get; set; }

        [Required]
        public float NetTotal { get; set; }

        [DefaultValue(false)]
        public bool IsReturned { get; set; }
    }
}