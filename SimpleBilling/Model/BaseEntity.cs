using System;
using System.ComponentModel;

namespace SimpleBilling.Model
{
    public class BaseEntity
    {
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        [DefaultValue(true)]
        public bool IsDeleted { get; set; }
    }
}
