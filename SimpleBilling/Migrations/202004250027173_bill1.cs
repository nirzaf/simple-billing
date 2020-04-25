namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bill1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GRNDetails", "Discount", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GRNDetails", "Discount");
        }
    }
}
