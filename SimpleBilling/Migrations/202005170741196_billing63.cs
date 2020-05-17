namespace SimpleBilling.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class billing63 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchaseOrders", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.PurchaseOrders", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.PurchaseOrders", "IsDeleted", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.PurchaseOrders", "IsDeleted");
            DropColumn("dbo.PurchaseOrders", "UpdatedDate");
            DropColumn("dbo.PurchaseOrders", "CreatedDate");
        }
    }
}
