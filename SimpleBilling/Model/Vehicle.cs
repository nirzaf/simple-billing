using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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

        public int OwnerId { get; set; }
        public DateTime AddedDate { get; set; }
        public virtual ICollection<MileageTracking> MileageTrackings { get; set; }
    }
}