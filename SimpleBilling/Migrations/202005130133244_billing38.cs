namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing38 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GRNDetails", "Returns", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GRNDetails", "Returns");
        }
    }
}
