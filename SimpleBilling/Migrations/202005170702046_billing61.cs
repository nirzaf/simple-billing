namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing61 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderedItems", "UnitType", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderedItems", "UnitType");
        }
    }
}
