namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing43 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Settings", "GRNPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Settings", "GRNPath");
        }
    }
}
