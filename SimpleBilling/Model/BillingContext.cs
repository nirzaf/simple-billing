using System.Data.Entity;

namespace SimpleBilling.Model
{
    public class BillingContext : DbContext
    {
        public BillingContext() : base("SimpleBilling")
        {
            Database.SetInitializer(new BillingDBInitializer());
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
