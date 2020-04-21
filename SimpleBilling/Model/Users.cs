using System.ComponentModel.DataAnnotations;

namespace SimpleBilling.Model
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int UserType { get; set; }
        public int IsDeleted { get; set; }
    }
}
