namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing22 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MileageTrackings",
                c => new
                    {
                        MileageId = c.Int(nullable: false, identity: true),
                        Mileage = c.Int(nullable: false),
                        Vehicles_VehicleNo = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MileageId)
                .ForeignKey("dbo.Vehicles", t => t.Vehicles_VehicleNo)
                .Index(t => t.Vehicles_VehicleNo);
            
            AddColumn("dbo.Vehicles", "Vehicle_VehicleNo", c => c.String(maxLength: 128));
            CreateIndex("dbo.Vehicles", "Vehicle_VehicleNo");
            AddForeignKey("dbo.Vehicles", "Vehicle_VehicleNo", "dbo.Vehicles", "VehicleNo");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MileageTrackings", "Vehicles_VehicleNo", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "Vehicle_VehicleNo", "dbo.Vehicles");
            DropIndex("dbo.Vehicles", new[] { "Vehicle_VehicleNo" });
            DropIndex("dbo.MileageTrackings", new[] { "Vehicles_VehicleNo" });
            DropColumn("dbo.Vehicles", "Vehicle_VehicleNo");
            DropTable("dbo.MileageTrackings");
        }
    }
}
