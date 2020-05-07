namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing32 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cheques", "Bank", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cheques", "Bank", c => c.String(maxLength: 50));
        }
    }
}
