namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing9 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReceiptBodies",
                c => new
                    {
                        ReceiptId = c.Int(nullable: false),
                        LineId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        ProductCode = c.String(nullable: false),
                        ProductName = c.String(nullable: false),
                        UnitPrice = c.Single(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Discount = c.Single(nullable: false),
                        SubTotal = c.Single(nullable: false),
                        NetTotal = c.Single(nullable: false),
                    })
                .PrimaryKey(t => new { t.ReceiptId, t.LineId });
            
            CreateTable(
                "dbo.ReceiptHeaders",
                c => new
                    {
                        ReceiptId = c.Int(nullable: false, identity: true),
                        ReceiptNo = c.String(nullable: false, maxLength: 200),
                        Date = c.String(nullable: false),
                        Time = c.String(nullable: false),
                        Cashier = c.Int(nullable: false),
                        TotalDiscount = c.Single(nullable: false),
                        SubTotal = c.Single(nullable: false),
                        NetTotal = c.Single(nullable: false),
                        PaymentType = c.String(maxLength: 10),
                        PaidAmount = c.Single(nullable: false),
                        Balance = c.Single(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReceiptId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ReceiptHeaders");
            DropTable("dbo.ReceiptBodies");
        }
    }
}
