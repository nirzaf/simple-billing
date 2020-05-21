namespace SimpleBilling.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class billing66 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Settings", "QuotationPath", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.Settings", "QuotationPath");
        }
    }
}
