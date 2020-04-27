namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.GRNDetails");
            AddPrimaryKey("dbo.GRNDetails", new[] { "GRN_Id", "GRNCode", "LineId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.GRNDetails");
            AddPrimaryKey("dbo.GRNDetails", new[] { "GRN_Id", "GRNCode", "LineId", "ProductId" });
        }
    }
}
