namespace SimpleBilling.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class billing55 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Banks", "RowVersion");
            DropColumn("dbo.BusinessModels", "RowVersion");
            DropColumn("dbo.Categories", "RowVersion");
            DropColumn("dbo.Items", "RowVersion");
            DropColumn("dbo.Shelves", "RowVersion");
            DropColumn("dbo.Cheques", "RowVersion");
            DropColumn("dbo.Customers", "RowVersion");
            DropColumn("dbo.Employees", "RowVersion");
            DropColumn("dbo.GRNDetails", "RowVersion");
            DropColumn("dbo.GRNHeaders", "RowVersion");
            DropColumn("dbo.Suppliers", "RowVersion");
            DropColumn("dbo.MileageTrackings", "RowVersion");
            DropColumn("dbo.ReceiptBodies", "RowVersion");
            DropColumn("dbo.ReceiptHeaders", "RowVersion");
            DropColumn("dbo.Settings", "RowVersion");
            DropColumn("dbo.Users", "RowVersion");
            DropColumn("dbo.Vehicles", "RowVersion");
        }

        public override void Down()
        {
            AddColumn("dbo.Vehicles", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Users", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Settings", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.ReceiptHeaders", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.ReceiptBodies", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.MileageTrackings", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Suppliers", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.GRNHeaders", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.GRNDetails", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Employees", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Customers", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Cheques", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Shelves", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Items", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Categories", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.BusinessModels", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Banks", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
    }
}
