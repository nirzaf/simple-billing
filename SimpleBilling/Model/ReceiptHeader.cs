using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBilling.Model
{
    public class ReceiptHeader
    {
        [Key]
        public int ReceiptId { get; set; }
        [Required]
        public string Date  { get; set; }
        [Required]
        public string Time { get; set; }
        [Required]
        public int Cashier { get; set; }
        [DefaultValue(0)]
        public float TotalDiscount { get; set; }
        [DefaultValue(0)]       
        public float TotalPrice { get; set; }

    }
}
