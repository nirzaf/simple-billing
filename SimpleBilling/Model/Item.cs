using System.ComponentModel.DataAnnotations;

namespace SimpleBilling.Model
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string  Code { get; set; }
        public string ItemName { get; set; }
        public string Unit { get; set; }
        public string Barcode { get; set; }
        public virtual Category Categories { get; set; }
    }
}
