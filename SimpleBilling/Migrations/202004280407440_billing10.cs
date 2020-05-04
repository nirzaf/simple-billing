namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class billing10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReceiptBodies", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.ReceiptHeaders", "IsDeleted", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.ReceiptHeaders", "IsDeleted");
            DropColumn("dbo.ReceiptBodies", "IsDeleted");
        }
    }
}