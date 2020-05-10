namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing34 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "PrintableName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "PrintableName");
        }
    }
}
