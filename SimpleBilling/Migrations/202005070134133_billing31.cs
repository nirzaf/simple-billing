using System;
using System.Data.Entity.Migrations;

namespace SimpleBilling.Migrations
{
    public partial class billing31 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Banks",
                c => new
                {
                    BankId = c.Int(nullable: false, identity: true),
                    BankName = c.String(maxLength: 100),
                    CreatedDate = c.DateTime(),
                    UpdatedDate = c.DateTime(),
                    IsDeleted = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.BankId);
        }

        public override void Down()
        {
            DropTable("dbo.Banks");
        }
    }
}