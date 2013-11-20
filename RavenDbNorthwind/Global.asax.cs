using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Raven.Client.Document;
using Raven.Client.Indexes;

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
            AutoMapperConfig.Configure();

            Store = new DocumentStore{ConnectionStringName = "RavenDb"};
            Store.Initialize();
            IndexCreation.CreateIndexes(Assembly.GetCallingAssembly(), Store);
        }
    }
}
