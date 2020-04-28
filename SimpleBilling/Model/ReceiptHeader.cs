﻿using System;
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
        [MaxLength(200)]
        public string ReceiptNo { get; set; }
        [Required]
        public string Date  { get; set; }
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
        public float PaidAmount { get; set; }
        public float Balance { get; set; }
        public int Status { get; set; }
    }
}
