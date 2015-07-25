namespace CarsInventory.DataContext.InventoryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConstraintsToVehicleTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehicles", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Vehicles", "RegistrationNo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicles", "RegistrationNo", c => c.String());
            AlterColumn("dbo.Vehicles", "Description", c => c.String());
        }
    }
}
