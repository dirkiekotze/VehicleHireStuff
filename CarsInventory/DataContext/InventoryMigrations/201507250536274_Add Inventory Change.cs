namespace CarsInventory.DataContext.InventoryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInventoryChange : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        VehicleId = c.Int(nullable: false),
                        Hirer = c.String(nullable: false),
                        EMailAddress = c.String(),
                        Telephone = c.String(),
                        Destination = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Comment = c.String(),
                        Price = c.Double(nullable: false),
                        NumberOFDays = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceId);
            
            DropColumn("dbo.Vehicles", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicles", "Price", c => c.Double(nullable: false));
            DropTable("dbo.Invoices");
        }
    }
}
