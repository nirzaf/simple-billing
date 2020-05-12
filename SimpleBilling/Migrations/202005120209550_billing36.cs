namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing36 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GRNHeaders", "ChequeNo", c => c.String(maxLength: 30));
            AddColumn("dbo.ReceiptHeaders", "ChequeNo", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReceiptHeaders", "ChequeNo");
            DropColumn("dbo.GRNHeaders", "ChequeNo");
        }
    }
}
