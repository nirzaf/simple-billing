namespace SimpleBilling.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class billing46 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GRNDetails", "GrossTotal", c => c.Single(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.GRNDetails", "GrossTotal");
        }
    }
}