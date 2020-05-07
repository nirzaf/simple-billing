using Microsoft.OData.Edm;

namespace SimpleBilling.Model
{
    public class Cheque : BaseEntity
    {
        public string ChequeNo { get; set; }
        public string PayeeName { get; set; }
        public Date DueDate { get; set; }
        public float Amount { get; set; }
    }
}