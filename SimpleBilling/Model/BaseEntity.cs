using System;
using System.ComponentModel;

namespace SimpleBilling.Model
{
    public class BaseEntity
    {
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
