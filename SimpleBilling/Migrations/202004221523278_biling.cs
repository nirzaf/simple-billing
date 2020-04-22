namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class biling : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Name", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Name");
        }
    }
}
