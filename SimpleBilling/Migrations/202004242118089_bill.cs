namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bill : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "SecretCode", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "SecretCode");
        }
    }
}
