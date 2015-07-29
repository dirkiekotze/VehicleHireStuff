using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsInventory.Infastructure.Tasks
{
    public interface IRunOnEachRequest
    {
        void Execute();
    }
}