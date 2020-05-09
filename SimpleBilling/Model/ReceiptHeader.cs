using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SimpleBilling.Model
{
    public class ReceiptHeader : BaseEntity
    {
        [Key]
        [MaxLength(200)]
        public string ReceiptNo { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public string Time { get; set; }

        [Required]
        public int Cashier { get; set; }

        [DefaultValue(0)]
        public float TotalDiscount { get; set; }

        public float SubTotal { get; set; }

        [DefaultValue(0)]
        public float NetTotal { get; set; }

        [MaxLength(10)]
        public string PaymentType { get; set; }

        [DefaultValue("No Remarks Found")]
        public string Remarks { get; set; }

        public int CustomerId { get; set; }

        public string VehicleNumber { get; set; }
        public float PaidAmount { get; set; }
        public float Balance { get; set; }

        [DefaultValue(0)]
        public int Status { get; set; }

        [DefaultValue(false)]
        public bool IsQuotation { get; set; }
    }
}