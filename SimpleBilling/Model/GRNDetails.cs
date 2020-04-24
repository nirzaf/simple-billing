using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBilling.Model
{
    public class GRNDetails
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
        [Key]
        [Column(Order = 4)]
        public int ProductId { get; set; }
        public float UnitCost { get; set; }
        public int Quantity { get; set; }
        public float SubTotal { get; set; }
    }
}
