using System.ComponentModel.DataAnnotations;

namespace SimpleBilling.Model
{
    public class Customers : BaseEntity
    {
        [Key]
        public int CustomerId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(25)]
        public string Contact { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(250)]
        public string Address { get; set; }
    }
}
