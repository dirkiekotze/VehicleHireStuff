using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CarsInventory.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CarsInventory.DataContext
{
    public class IdentityDb : IdentityDbContext<ApplicationUser>
    {
        public IdentityDb()
            : base("DefaultConnection")
        {
        }

        public static IdentityDb Create()
        {
            return new IdentityDb();
        }

        
    }
}