using System.Data.Entity.ModelConfiguration;

namespace SimpleBilling.Model
{
    public class UserTypeConfigurations : EntityTypeConfiguration<Users>
    {
        public UserTypeConfigurations()
        {
            Property(s => s.Username).IsRequired().HasMaxLength(50);

            Property(s => s.Username).IsConcurrencyToken();
        }
    }
}
