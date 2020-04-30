using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SimpleBilling.Model
{
    public class Shelf
    {   
        [Key]
        public int ShelId { get; set; }
        [Required]
        [MaxLength(150)]
        public string ShelfName { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
