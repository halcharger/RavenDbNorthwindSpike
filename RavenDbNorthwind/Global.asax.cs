using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Raven.Client.Document;
using RavenDbNorthwind.App_Start;

namespace RavenDbNorthwind
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static DocumentStore Store;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new FeatureViewLocationRazorViewEngine());

            DependencyResolution.StructureMap.Configure();
            AutoMapperConfig.Configure();
        }
    }
}
