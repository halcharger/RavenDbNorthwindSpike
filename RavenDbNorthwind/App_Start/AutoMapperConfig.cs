using System.Web.Mvc;
using AutoMapper;
using Raven.Client;
using RavenDbNorthwind.Db;
using RavenDbNorthwind.Features.Categories;
using RavenDbNorthwind.Features.Products;

namespace RavenDbNorthwind
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Configuration.ConstructServicesUsing(DependencyResolver.Current.GetService);

            Mapper.CreateMap<Product, ProductModel>()
                  .ForMember(d => d.CategoryName, opt => opt.ResolveUsing<CategoryNameResolver>())
                  .ForMember(d => d.SupplierName, opt => opt.ResolveUsing<SupplierNameResolver>());

            Mapper.CreateMap<CreateCategoryModel, Category>();
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

    public class CategoryNameResolver : ValueResolver<Product, string>
    {
        private readonly IDocumentSession RavenSession;

        public CategoryNameResolver(IDocumentSession ravenSession)
        {
            RavenSession = ravenSession;
        }

        protected override string ResolveCore(Product source)
        {
            return RavenSession.Load<Category>(source.Category).Name;
        }
    }
}