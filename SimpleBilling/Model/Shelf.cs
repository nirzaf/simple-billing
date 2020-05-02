using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SimpleBilling.Model
{
    public class Shelf : BaseEntity
    {   
        [Key]
        public int ShelfId { get; set; }
        [Required]
        [MaxLength(150)]
        public string ShelfName { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
