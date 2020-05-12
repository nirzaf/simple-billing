namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing37 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GRNDetails", "IsReturned", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GRNDetails", "IsReturned");
        }
    }
}
