using System.ComponentModel.DataAnnotations;

namespace SimpleBilling.Model
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [MaxLength(150)]
        public string CategoryName { get; set; }
    }
}
