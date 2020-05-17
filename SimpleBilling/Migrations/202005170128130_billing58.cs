namespace SimpleBilling.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class billing58 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PendingJobs",
                c => new
                {
                    ReceiptNo = c.String(nullable: false, maxLength: 128),
                    VehicleNumber = c.String(maxLength: 30),
                    Date = c.String(maxLength: 30),
                    CreatedDate = c.DateTime(),
                    UpdatedDate = c.DateTime(),
                    IsDeleted = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.ReceiptNo);

        }

        public override void Down()
        {
            DropTable("dbo.PendingJobs");
        }
    }
}
