namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing35 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GRNHeaders", "PaymentType", c => c.String(maxLength: 10));
            AddColumn("dbo.GRNHeaders", "IsPaid", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GRNHeaders", "IsPaid");
            DropColumn("dbo.GRNHeaders", "PaymentType");
        }
    }
}
