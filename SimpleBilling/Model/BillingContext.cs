using System.Data.Entity;

namespace SimpleBilling.Model
{
    public class BillingContext : DbContext
    {
        public BillingContext() : base("name=con"){ }
        public DbSet<Users> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<GRNHeader> GRNHeaders { get; set; }
        public DbSet<GRNDetails> GRNDetails { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<ReceiptHeader> ReceiptHeaders { get; set; }
        public DbSet<ReceiptBody> ReceiptBodies { get; set; }
        public DbSet<Shelf> Shelves { get; set; }
    }
}
