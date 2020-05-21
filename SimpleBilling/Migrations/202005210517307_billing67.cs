namespace SimpleBilling.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class billing67 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "EmployeeId", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "Name");
        }

        public override void Down()
        {
            AddColumn("dbo.Users", "Name", c => c.String(maxLength: 150));
            DropColumn("dbo.Users", "EmployeeId");
        }
    }
}
