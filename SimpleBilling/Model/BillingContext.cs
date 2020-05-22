using System.Data.Entity;

namespace SimpleBilling.Model
{
    public class BillingContext : DbContext
    {
        public BillingContext() : base("name=con")
        {
            Database.SetInitializer(new BillingDBInitializer());
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<GrnHeader> GRNHeaders { get; set; }
        public DbSet<GrnDetails> GRNDetails { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<ReceiptHeader> ReceiptHeaders { get; set; }
        public DbSet<ReceiptBody> ReceiptBodies { get; set; }
        public DbSet<Shelf> Shelves { get; set; }
        public DbSet<BusinessModel> BusinessModels { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<MileageTracking> MileTracking { get; set; }
        public DbSet<Cheque> Cheques { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<PendingJob> PendingJobs { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<OrderedItem> OrderedItems { get; set; }
    }
}