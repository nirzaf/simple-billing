using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBilling.Model
{
    public class ReceiptBody
    {
        [Key]
        [Column(Order = 1)]
        public int ReceiptId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int LineId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string ProductCode { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public float UnitPrice { get; set; }
        [Required]
        public int Quantity { get; set; }
        [DefaultValue(0)]
        public float Discount { get; set; }
        public float SubTotal { get; set; }
        [Required]
        public float NetTotal { get; set; }

    }
}
