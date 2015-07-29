using System;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace CarsInventory.Infastructure.Tasks
{
    public class TaskRegistry : Registry
    {

        public TaskRegistry()
        {
            Scan(scan =>
            {
                scan.AssembliesFromApplicationBaseDirectory(
                    a => a.FullName.StartsWith("CarsInventory"));
                scan.AddAllTypesOf<IRunAtInit>();
                scan.AddAllTypesOf<IRunAtStartup>();
                scan.AddAllTypesOf<IRunOnEachRequest>();
                scan.AddAllTypesOf<IRunAfterEachRequest>();
                scan.AddAllTypesOf<IRunOnError>();

            });
            ;
        }
    }
}