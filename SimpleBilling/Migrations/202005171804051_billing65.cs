namespace SimpleBilling.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class billing65 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.OrderedItems");
            AlterColumn("dbo.OrderedItems", "OrderedDate", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.OrderedItems", new[] { "ItemCode", "OrderedDate" });
        }

        public override void Down()
        {
            DropPrimaryKey("dbo.OrderedItems");
            AlterColumn("dbo.OrderedItems", "OrderedDate", c => c.String());
            AddPrimaryKey("dbo.OrderedItems", "ItemCode");
        }
    }
}
