namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing3 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.OrderedItems");
            AddColumn("dbo.OrderedItems", "OrderId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.OrderedItems", "SupplierId", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderedItems", "ItemCode", c => c.String());
            AlterColumn("dbo.OrderedItems", "OrderedDate", c => c.String());
            AddPrimaryKey("dbo.OrderedItems", "OrderId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.OrderedItems");
            AlterColumn("dbo.OrderedItems", "OrderedDate", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.OrderedItems", "ItemCode", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.OrderedItems", "SupplierId");
            DropColumn("dbo.OrderedItems", "OrderId");
            AddPrimaryKey("dbo.OrderedItems", new[] { "ItemCode", "OrderedDate" });
        }
    }
}
