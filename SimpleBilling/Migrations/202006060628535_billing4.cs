namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing4 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.OrderedItems");
            DropPrimaryKey("dbo.PurchaseOrders");
            AddColumn("dbo.PurchaseOrders", "OrderUniqueId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.PurchaseOrders", "OrderedDate", c => c.String());
            AddColumn("dbo.PurchaseOrders", "SupplierId", c => c.Int(nullable: false));
            AddColumn("dbo.PurchaseOrders", "IsOrderCompleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.OrderedItems", "ItemCode", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.OrderedItems", new[] { "ItemCode", "OrderId" });
            AddPrimaryKey("dbo.PurchaseOrders", "OrderUniqueId");
            DropColumn("dbo.OrderedItems", "OrderedDate");
            DropColumn("dbo.OrderedItems", "SupplierId");
            DropColumn("dbo.PurchaseOrders", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PurchaseOrders", "Date", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.OrderedItems", "SupplierId", c => c.Int(nullable: false));
            AddColumn("dbo.OrderedItems", "OrderedDate", c => c.String());
            DropPrimaryKey("dbo.PurchaseOrders");
            DropPrimaryKey("dbo.OrderedItems");
            AlterColumn("dbo.OrderedItems", "ItemCode", c => c.String());
            DropColumn("dbo.PurchaseOrders", "IsOrderCompleted");
            DropColumn("dbo.PurchaseOrders", "SupplierId");
            DropColumn("dbo.PurchaseOrders", "OrderedDate");
            DropColumn("dbo.PurchaseOrders", "OrderUniqueId");
            AddPrimaryKey("dbo.PurchaseOrders", "Date");
            AddPrimaryKey("dbo.OrderedItems", "OrderId");
        }
    }
}
