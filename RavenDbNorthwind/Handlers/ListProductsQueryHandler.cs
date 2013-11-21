using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Raven.Client;
using RavenDbNorthwind.Models.Db;
using RavenDbNorthwind.Models.View;
using RavenDbNorthwind.Queries;
using ShortBus;

namespace RavenDbNorthwind.Handlers
{
    public class ListProductsQueryHandler : IQueryHandler<ListProductsQuery, IEnumerable<ProductViewModel>>
    {
        private readonly IDocumentSession session;

        public ListProductsQueryHandler(IDocumentSession session)
        {
            this.session = session;
        }

        public IEnumerable<ProductViewModel> Handle(ListProductsQuery request)
        {
            var dbProducts = session.Query<Product>()
                                       .Customize(q =>
                                       {
                                           q.Include<Product, Category>(p => p.Category);
                                           q.Include<Product, Supplier>(p => p.Supplier);
                                       })
                                       .ToList();

            return dbProducts.Select(Mapper.Map<ProductViewModel>);
        }
    }
}