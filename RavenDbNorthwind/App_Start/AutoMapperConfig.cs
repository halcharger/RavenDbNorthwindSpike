using System.Web.Mvc;
using AutoMapper;
using Raven.Client;
using RavenDbNorthwind.Models.Db;
using RavenDbNorthwind.Models.View;

namespace RavenDbNorthwind
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Configuration.ConstructServicesUsing(DependencyResolver.Current.GetService);

            Mapper.CreateMap<Product, ProductViewModel>()
                  .ForMember(d => d.SupplierName, opt => opt.ResolveUsing<SupplierNameResolver>());
        }
    }

    public class SupplierNameResolver : ValueResolver<Product, string>
    {
        private readonly IDocumentSession RavenSession;

        public SupplierNameResolver(IDocumentSession ravenSession)
        {
            RavenSession = ravenSession;
        }

        protected override string ResolveCore(Product source)
        {
            return RavenSession.Load<Supplier>(source.Supplier).Name;
        }
    }
}