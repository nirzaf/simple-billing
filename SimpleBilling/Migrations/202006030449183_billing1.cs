namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SMSLogs",
                c => new
                    {
                        LogKey = c.String(nullable: false, maxLength: 128),
                        LogMessage = c.String(),
                        Number = c.String(),
                        Log = c.String(),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LogKey);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SMSLogs");
        }
    }
}
