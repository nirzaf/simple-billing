namespace SimpleBilling.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class billing62 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderedItems", "PurchaseOrderId", c => c.Int(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.OrderedItems", "PurchaseOrderId");
        }
    }
}
