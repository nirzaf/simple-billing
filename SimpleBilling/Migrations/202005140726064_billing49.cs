namespace SimpleBilling.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class billing49 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReceiptHeaders", "PaidValue", c => c.Single(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.ReceiptHeaders", "PaidValue");
        }
    }
}
