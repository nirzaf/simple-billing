using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBilling.Model
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [MaxLength(150)]
        public string  EmployeeName { get; set; }
        [MaxLength(25)]
        public string Contact { get; set; }
        [MaxLength(250)]
        public string Address { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public int Status { get; set; }
        [MaxLength(10)]
        public string SecretCode { get; set; }
    }
}
