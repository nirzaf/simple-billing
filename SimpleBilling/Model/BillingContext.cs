using System.Data.Entity;

namespace SimpleBilling.Model
{
    public class BillingContext : DbContext
    {
        public BillingContext() : base("Billing")
        {
            Database.SetInitializer(new BillingDBInitializer());
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Adds configurations for Student from separate class
            modelBuilder.Configurations.Add(new UserTypeConfigurations());

            modelBuilder.Entity<Users>()
                .ToTable("UserInfo");

            modelBuilder.Entity<Users>()
                .MapToStoredProcedures();
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
