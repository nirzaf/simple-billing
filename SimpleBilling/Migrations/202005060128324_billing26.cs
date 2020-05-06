namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing26 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MileageTrackings", "Vehicles_VehicleNo", "dbo.Vehicles");
            DropIndex("dbo.MileageTrackings", new[] { "Vehicles_VehicleNo" });
            AddColumn("dbo.MileageTrackings", "VehicleNo", c => c.String());
            DropColumn("dbo.MileageTrackings", "Vehicles_VehicleNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MileageTrackings", "Vehicles_VehicleNo", c => c.String(maxLength: 128));
            DropColumn("dbo.MileageTrackings", "VehicleNo");
            CreateIndex("dbo.MileageTrackings", "Vehicles_VehicleNo");
            AddForeignKey("dbo.MileageTrackings", "Vehicles_VehicleNo", "dbo.Vehicles", "VehicleNo");
        }
    }
}
