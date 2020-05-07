using System.ComponentModel.DataAnnotations;

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