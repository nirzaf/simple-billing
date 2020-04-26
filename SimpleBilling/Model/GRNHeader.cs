using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleBilling.Model
{
    public class GRNHeader
    {
        [Key]
        public int GRN_Id { get; set; }

        public string GRN_No { get; set; }
        public string GRN_Date { get; set; }
        public string ReferenceNo { get; set; }
        public virtual Supplier Supplier { get; set; }
        public float GrossTotal { get; set; }
        [DefaultValue(0)]
        public float TotalDiscout { get; set; }
        public float NetTotal { get; set; }
        public int Status { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
