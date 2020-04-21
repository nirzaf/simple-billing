using System.Data.Entity.Migrations;

namespace SimpleBilling.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Model.BillingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Model.BillingContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
