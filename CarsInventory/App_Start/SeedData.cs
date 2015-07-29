using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using CarsInventory.DataContext;
using CarsInventory.Infastructure.Tasks;
using CarsInventory.Models;

namespace CarsInventory.App_Start
{
    public class SeedData: IRunAtStartup
    {
        private IdentityDb _context;


        public SeedData(IdentityDb context)
        {
            _context = context;
        }

        public void Execute()
        {
            if (!_context.Users.Any())
            {
                var user1 = _context.Users.FirstOrDefault(u => u.UserName == "DougStone") ??
                        _context.Users.Add(new ApplicationUser { UserName = "DougStone" });

                _context.SaveChanges();
            }

        }
    }
}