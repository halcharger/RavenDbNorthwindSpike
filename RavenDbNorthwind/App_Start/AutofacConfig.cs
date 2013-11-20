using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Indexes;

namespace RavenDbNorthwind
{
    public class AutofacConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            //register RavenDb DocumentStore
            builder.Register(x =>
            {
                var store = new DocumentStore { ConnectionStringName = "RavenDb" };
                store.Initialize();
                IndexCreation.CreateIndexes(Assembly.GetCallingAssembly(), store);
                return store;
            });

            //register RavenDb DocumentSession per Http request and SaveChanges on release of scope
            builder.Register(x => x.Resolve<DocumentStore>().OpenSession())
                .As<IDocumentSession>()
                .InstancePerHttpRequest();
                   //.OnRelease(x => { using (x) { x.SaveChanges(); } });

            builder.RegisterType<SupplierNameResolver>().InstancePerHttpRequest();
            builder.RegisterType<CategoryNameResolver>().InstancePerHttpRequest();
            
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}