using System.Security.Principal;
using CarsInventory.DataContext;
using CarsInventory.Models;
using Microsoft.AspNet.Identity;

namespace CarsInventory.Infastructure
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IIdentity _identity;
        private readonly IdentityDb _context;
        private ApplicationUser _user;

        public CurrentUser(IIdentity identity, IdentityDb context)
        {
            _identity = identity;
            _context = context;
        }

        public ApplicationUser User
        {
            get
            {
                return _user ?? (_user = _context.Users.Find(_identity.GetUserId()));
            }
        }
    }
}