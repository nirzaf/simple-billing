namespace SimpleBilling.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class billing53 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.GRNDetails", "LineId");
        }

        public override void Down()
        {
            AddColumn("dbo.GRNDetails", "LineId", c => c.Int(nullable: false));
        }
    }
}
