namespace CarsInventory.DataContext.InventoryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInventory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "Price");
        }
    }
}
