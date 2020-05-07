namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing29 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cheques", "DueDate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cheques", "DueDate");
        }
    }
}
