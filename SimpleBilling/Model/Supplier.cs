using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleBilling.Model
{
    public class Supplier : BaseEntity
    {
        [Key]
        public int SupplierId { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }
        [MaxLength(25)]
        [Required]
        public string Contact { get; set; }
        public string Address { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string CodeNumber { get; set; }

    }
}
