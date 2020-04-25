namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "GRNHeader_GRN_Id", c => c.Int());
            CreateIndex("dbo.Items", "GRNHeader_GRN_Id");
            AddForeignKey("dbo.Items", "GRNHeader_GRN_Id", "dbo.GRNHeaders", "GRN_Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "GRNHeader_GRN_Id", "dbo.GRNHeaders");
            DropIndex("dbo.Items", new[] { "GRNHeader_GRN_Id" });
            DropColumn("dbo.Items", "GRNHeader_GRN_Id");
        }
    }
}
