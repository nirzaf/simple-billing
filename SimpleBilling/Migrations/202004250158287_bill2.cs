namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bill2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.GRNDetails");
            AddColumn("dbo.GRNDetails", "ProductId_Id", c => c.Int());
            AddPrimaryKey("dbo.GRNDetails", new[] { "GRN_Id", "GRNCode", "LineId" });
            CreateIndex("dbo.GRNDetails", "ProductId_Id");
            AddForeignKey("dbo.GRNDetails", "ProductId_Id", "dbo.Items", "Id");
            DropColumn("dbo.GRNDetails", "ProductId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GRNDetails", "ProductId", c => c.Int(nullable: false));
            DropForeignKey("dbo.GRNDetails", "ProductId_Id", "dbo.Items");
            DropIndex("dbo.GRNDetails", new[] { "ProductId_Id" });
            DropPrimaryKey("dbo.GRNDetails");
            DropColumn("dbo.GRNDetails", "ProductId_Id");
            AddPrimaryKey("dbo.GRNDetails", new[] { "GRN_Id", "GRNCode", "LineId", "ProductId" });
        }
    }
}
