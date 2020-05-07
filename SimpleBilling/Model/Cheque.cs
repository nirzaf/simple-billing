using Microsoft.OData.Edm;
using System.ComponentModel.DataAnnotations;

namespace SimpleBilling.Model
{
    public class Cheque : BaseEntity
    {
        [Key]
        public string ChequeNo { get; set; }

        [MaxLength(150)]
        public string PayeeName { get; set; }

        public Date DueDate { get; set; }
        public float Amount { get; set; }
        public int PaidBy { get; set; }

        [MaxLength(50)]
        public string Bank { get; set; }
    }
}