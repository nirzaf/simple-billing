using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleBilling.Model
{
    public class Category
    {
        public Category()
        {
            Items = new HashSet<Item>();
        }

        [Key]
        public int CategoryId { get; set; }

        [MaxLength(150)]
        public string CategoryName { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
