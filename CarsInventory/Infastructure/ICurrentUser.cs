using CarsInventory.Models;

namespace CarsInventory.Infastructure
{
    public interface ICurrentUser
    {
        ApplicationUser User { get; } 
    }
}