using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SimpleBilling.Model
{
    public class GrnHeader : BaseEntity
    {
        [Key]
        public int GRN_Id { get; set; }

        public string GRN_No { get; set; }
        public string GRN_Date { get; set; }
        public string Time { get; set; }
        public string ReferenceNo { get; set; }

        [MaxLength(10)]
        public string PaymentType { get; set; }

        [DefaultValue(false)]
        public bool IsPaid { get; set; }

        public virtual Supplier Supplier { get; set; }
        public float GrossTotal { get; set; }

        [DefaultValue(0)]
        public float TotalDiscout { get; set; }

        [DefaultValue(0)]
        public float Returns { get; set; }

        public float NetTotal { get; set; }
        public int Status { get; set; }
        public virtual Employee Employee { get; set; }

        [MaxLength(30)]
        public string ChequeNo { get; set; }

        [DefaultValue(0)]
        public float PaidAmount { get; set; }

        [DefaultValue(0)]
        public float PendingAmount { get; set; }

        public string Remarks { get; set; }
    }
}