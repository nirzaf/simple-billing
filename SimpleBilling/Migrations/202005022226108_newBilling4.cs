namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newBilling4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VehicleNo = c.String(nullable: false, maxLength: 128),
                        Brand = c.String(maxLength: 100),
                        Model = c.String(maxLength: 100),
                        Type = c.String(),
                        CurrentMileage = c.Int(nullable: false),
                        ServiceMileageDue = c.Int(nullable: false),
                        OwnerId = c.Int(),
                        AddedDate = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleNo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vehicles");
        }
    }
}
