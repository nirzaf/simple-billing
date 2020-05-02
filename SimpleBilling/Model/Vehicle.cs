using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBilling.Model
{
    public class Vehicle : BaseEntity
    {
        [Key]
        public string VehicleNo { get; set; }
        [MaxLength(100)]
        public string Brand { get; set; }
        [MaxLength(100)]
        public string Model { get; set; }
        public string Type { get; set; }
        [DefaultValue(0)]
        public int CurrentMileage { get; set; }
        [DefaultValue(0)]
        public int ServiceMileageDue { get; set; }
        public int? OwnerId { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
