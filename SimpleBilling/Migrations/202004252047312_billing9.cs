namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GRNDetails", "ProductId_Id", "dbo.Items");
            DropForeignKey("dbo.Items", "GRNHeader_GRN_Id", "dbo.GRNHeaders");
            DropIndex("dbo.Items", new[] { "GRNHeader_GRN_Id" });
            DropIndex("dbo.GRNDetails", new[] { "ProductId_Id" });
            DropPrimaryKey("dbo.GRNDetails");
            AddColumn("dbo.GRNDetails", "ProductId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.GRNDetails", new[] { "GRN_Id", "GRNCode", "LineId", "ProductId" });
            DropColumn("dbo.Items", "GRNHeader_GRN_Id");
            DropColumn("dbo.GRNDetails", "ProductId_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GRNDetails", "ProductId_Id", c => c.Int());
            AddColumn("dbo.Items", "GRNHeader_GRN_Id", c => c.Int());
            DropPrimaryKey("dbo.GRNDetails");
            DropColumn("dbo.GRNDetails", "ProductId");
            AddPrimaryKey("dbo.GRNDetails", new[] { "GRN_Id", "GRNCode", "LineId" });
            CreateIndex("dbo.GRNDetails", "ProductId_Id");
            CreateIndex("dbo.Items", "GRNHeader_GRN_Id");
            AddForeignKey("dbo.Items", "GRNHeader_GRN_Id", "dbo.GRNHeaders", "GRN_Id");
            AddForeignKey("dbo.GRNDetails", "ProductId_Id", "dbo.Items", "Id");
        }
    }
}
