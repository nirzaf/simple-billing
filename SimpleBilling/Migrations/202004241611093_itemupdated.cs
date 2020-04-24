using System;
using System.Data.Entity.Migrations;

namespace SimpleBilling.Migrations
{
    public partial class itemupdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "StockQty", c => c.Int(defaultValue : 0, nullable: false));
            AlterColumn("dbo.Items", "Code", c => c.String(maxLength: 50));
            AlterColumn("dbo.Items", "ItemName", c => c.String(maxLength: 250));
            AlterColumn("dbo.Items", "Unit", c => c.String(maxLength: 25));
            AlterColumn("dbo.Items", "Barcode", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Items", "Barcode", c => c.String());
            AlterColumn("dbo.Items", "Unit", c => c.String());
            AlterColumn("dbo.Items", "ItemName", c => c.String());
            AlterColumn("dbo.Items", "Code", c => c.String());
            DropColumn("dbo.Items", "StockQty");
        }
    }
}
