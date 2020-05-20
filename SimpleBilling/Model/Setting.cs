using System.ComponentModel.DataAnnotations;

namespace SimpleBilling.Model
{
    public class Setting : BaseEntity
    {
        [Key]
        public int SettingsId { get; set; }
        public int UserId { get; set; }
        public string DefaultPath { get; set; }
        public string GRNPath { get; set; }
        public string ExceptionPath { get; set; }
        public int SetMinValue { get; set; }
    }
}