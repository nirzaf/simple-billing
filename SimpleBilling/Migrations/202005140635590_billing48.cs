namespace SimpleBilling.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class billing48 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReceiptHeaders", "PendingValue", c => c.Single(nullable: false));
            AddColumn("dbo.ReceiptHeaders", "IsPaid", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.ReceiptHeaders", "IsPaid");
            DropColumn("dbo.ReceiptHeaders", "PendingValue");
        }
    }
}
