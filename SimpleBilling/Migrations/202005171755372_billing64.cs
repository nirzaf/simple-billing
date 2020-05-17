namespace SimpleBilling.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class billing64 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.PurchaseOrders");
            AddColumn("dbo.OrderedItems", "OrderedDate", c => c.String());
            AlterColumn("dbo.PurchaseOrders", "Date", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.PurchaseOrders", "Date");
            DropColumn("dbo.OrderedItems", "PurchaseOrderId");
            DropColumn("dbo.PurchaseOrders", "PurchaseOrderId");
        }

        public override void Down()
        {
            AddColumn("dbo.PurchaseOrders", "PurchaseOrderId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.OrderedItems", "PurchaseOrderId", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.PurchaseOrders");
            AlterColumn("dbo.PurchaseOrders", "Date", c => c.String());
            DropColumn("dbo.OrderedItems", "OrderedDate");
            AddPrimaryKey("dbo.PurchaseOrders", "PurchaseOrderId");
        }
    }
}
