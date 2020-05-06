namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing23 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MileageTrackings", "ReceiptNo_ReceiptNo", c => c.String(maxLength: 200));
            CreateIndex("dbo.MileageTrackings", "ReceiptNo_ReceiptNo");
            AddForeignKey("dbo.MileageTrackings", "ReceiptNo_ReceiptNo", "dbo.ReceiptHeaders", "ReceiptNo");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MileageTrackings", "ReceiptNo_ReceiptNo", "dbo.ReceiptHeaders");
            DropIndex("dbo.MileageTrackings", new[] { "ReceiptNo_ReceiptNo" });
            DropColumn("dbo.MileageTrackings", "ReceiptNo_ReceiptNo");
        }
    }
}
