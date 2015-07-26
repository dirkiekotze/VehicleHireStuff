namespace CarsInventory.DataContext.InventoryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyVehicleIDtoInvoice : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Invoices", "VehicleId");
            AddForeignKey("dbo.Invoices", "VehicleId", "dbo.Vehicles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "VehicleId", "dbo.Vehicles");
            DropIndex("dbo.Invoices", new[] { "VehicleId" });
        }
    }
}
