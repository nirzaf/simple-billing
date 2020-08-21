namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Settings", "EnableSMS", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Settings", "EnableSMS");
        }
    }
}
