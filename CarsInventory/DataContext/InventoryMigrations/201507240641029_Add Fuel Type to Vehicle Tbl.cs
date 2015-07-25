namespace CarsInventory.DataContext.InventoryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFuelTypetoVehicleTbl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "FuelType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "FuelType");
        }
    }
}
