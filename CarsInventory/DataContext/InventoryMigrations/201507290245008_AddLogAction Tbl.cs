namespace CarsInventory.DataContext.InventoryMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLogActionTbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LogActions",
                c => new
                    {
                        LogActionId = c.Int(nullable: false, identity: true),
                        PerformedAt = c.DateTime(nullable: false),
                        Controller = c.String(),
                        Action = c.String(),
                        PerformedBy = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.LogActionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LogActions");
        }
    }
}
