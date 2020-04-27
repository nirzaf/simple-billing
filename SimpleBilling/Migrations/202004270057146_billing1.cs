namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GRNDetails", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GRNDetails", "IsDeleted");
        }
    }
}
