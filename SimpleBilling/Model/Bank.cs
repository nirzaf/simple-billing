using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBilling.Model
{
    public class Bank : BaseEntity
    {
        [Key]
        public int BankId { get; set; }

        [MaxLength(100)]
        public string BankName { get; set; }
    }
}