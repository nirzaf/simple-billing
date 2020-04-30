using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SimpleBilling.Model
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string  Code { get; set; }
        [MaxLength(250)]
        public string ItemName { get; set; }
        [MaxLength(25)]
        public string Unit { get; set; }
        public float UnitCost { get; set; }
        [MaxLength(250)]
        public string Barcode { get; set; }
        [DefaultValue(0)]
        public int StockQty { get; set; }
        public float SellingPrice { get; set; }
        [DefaultValue(false)]
        public bool Is_Service { get; set; }
        public virtual Category Categories { get; set; }

        public virtual Shelf Shelfs { get; set; }
    }
}
