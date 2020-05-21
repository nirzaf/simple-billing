using System.ComponentModel.DataAnnotations;

namespace SimpleBilling.Model
{
    public class Users : BaseEntity
    {
        [Key]
        public int UserId { get; set; }
        [MaxLength(50)]
        public string Username { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
        public int UserType { get; set; }
        public int EmployeeId { get; set; }
    }
}
