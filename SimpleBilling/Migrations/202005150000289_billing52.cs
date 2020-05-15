namespace SimpleBilling.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class billing52 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.GRNDetails");
            AddPrimaryKey("dbo.GRNDetails", new[] { "GRN_Id", "GRNCode", "ProductId" });
        }

        public override void Down()
        {
            DropPrimaryKey("dbo.GRNDetails");
            AddPrimaryKey("dbo.GRNDetails", new[] { "GRN_Id", "GRNCode", "LineId" });
        }
    }
}
