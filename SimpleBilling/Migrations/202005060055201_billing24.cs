namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing24 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MileageTrackings", "ReceiptNo_ReceiptNo", "dbo.ReceiptHeaders");
            DropIndex("dbo.MileageTrackings", new[] { "ReceiptNo_ReceiptNo" });
            AddColumn("dbo.MileageTrackings", "ReceiptNo", c => c.String());
            DropColumn("dbo.MileageTrackings", "ReceiptNo_ReceiptNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MileageTrackings", "ReceiptNo_ReceiptNo", c => c.String(maxLength: 200));
            DropColumn("dbo.MileageTrackings", "ReceiptNo");
            CreateIndex("dbo.MileageTrackings", "ReceiptNo_ReceiptNo");
            AddForeignKey("dbo.MileageTrackings", "ReceiptNo_ReceiptNo", "dbo.ReceiptHeaders", "ReceiptNo");
        }
    }
}
