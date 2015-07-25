using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CarsInventory.Entities;

namespace CarsInventory.DataContext
{
    public class InventoryDb : DbContext
    {

        public InventoryDb()
            : base("DefaultConnection")
        {

        }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Invoice> Invoice { get; set; }
    }
}