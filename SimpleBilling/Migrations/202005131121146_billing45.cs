namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing45 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GRNHeaders", "Time", c => c.String());
            AlterColumn("dbo.Cheques", "PaidBy", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cheques", "PaidBy", c => c.Int(nullable: false));
            DropColumn("dbo.GRNHeaders", "Time");
        }
    }
}
