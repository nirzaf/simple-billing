using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SimpleBilling.Model
{
    public class GRNHeader : BaseEntity
    {
        [Key]
        public int GRN_Id { get; set; }

        public string GRN_No { get; set; }
        public string GRN_Date { get; set; }
        public string ReferenceNo { get; set; }

        [MaxLength(10)]
        public string PaymentType { get; set; }

        public virtual Supplier Supplier { get; set; }
        public float GrossTotal { get; set; }

        [DefaultValue(0)]
        public float TotalDiscout { get; set; }

        public float NetTotal { get; set; }
        public int Status { get; set; }
        public virtual Employee Employee { get; set; }
    }
}