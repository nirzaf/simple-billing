namespace SimpleBilling.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class billing56 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Settings", "ExceptionPath", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.Settings", "ExceptionPath");
        }
    }
}
