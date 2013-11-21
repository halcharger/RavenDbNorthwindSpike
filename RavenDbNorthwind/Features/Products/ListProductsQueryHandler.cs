using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Raven.Client;
using RavenDbNorthwind.Db;
using RavenDbNorthwind.Features.Products;
using ShortBus;

namespace RavenDbNorthwind.Handlers
{
    public class ListProductsQueryHandler : IQueryHandler<ListProductsQuery, IEnumerable<ShowProductModel>>
    {
        private readonly IDocumentSession session;

        public ListProductsQueryHandler(IDocumentSession session)
        {
            this.session = session;
        }

        public IEnumerable<ShowProductModel> Handle(ListProductsQuery request)
        {
            var dbProducts = session.Query<Product>()
                                       .Customize(q =>
                                       {
                                           q.Include<Product, Category>(p => p.Category);
                                           q.Include<Product, Supplier>(p => p.Supplier);
                                       })
                                       .ToList();

            return dbProducts.Select(Mapper.Map<ShowProductModel>);
        }
    }
}