using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CarsInventory.Infastructure;
using StructureMap;
using StructureMap.Graph;

namespace CarsInventory
{

    public class MvcApplication : System.Web.HttpApplication
    {

        public IContainer Container
        {
            get
            {
                return (IContainer)HttpContext.Current.Items["_Container"];
            }
            set
            {
                HttpContext.Current.Items["_Container"] = value;
            }
        }
        


        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            DependencyResolver.SetResolver(new StructureMapDependencyResolver(() => Container ?? ObjectFactory.Container));

            ObjectFactory.Configure(cfg =>
            {
                cfg.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });

            });

        }

        public void Application_BeginRequest()
        {
            Container = ObjectFactory.Container.GetNestedContainer();

            //foreach (var task in Container.GetAllInstances<IRunOnEachRequest>())
            //{
            //    task.Execute();
            //}
        }

        public void Application_Error()
        {
            //foreach (var task in Container.GetAllInstances<IRunOnError>())
            //{
            //    task.Execute();
            //}
        }

        public void Application_EndRequest()
        {
            Container.Dispose();
            Container = null;
        }
    }
}
