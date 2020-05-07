namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing30 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cheques", "DueDate", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cheques", "DueDate", c => c.String());
        }
    }
}
