using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleBilling.Model
{
    public class GRNDetails : BaseEntity
    {
        [Key]
        [Column(Order = 1)]
        public int GRN_Id { get; set; }

        [Key]
        [Column(Order = 2)]
        public string GRNCode { get; set; }

        [Key]
        [Column(Order = 3)]
        public int LineId { get; set; }

        public int ProductId { get; set; }

        [DefaultValue(false)]
        public bool IsReturned { get; set; }

        [Required]
        public float UnitCost { get; set; }

        [Required]
        public int Quantity { get; set; }

        [DefaultValue(0)]
        public float Discount { get; set; }

        [DefaultValue(0)]
        public float Returns { get; set; }

        [Required]
        public float SubTotal { get; set; }
    }
}