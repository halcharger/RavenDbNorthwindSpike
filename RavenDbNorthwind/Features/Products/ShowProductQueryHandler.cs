using AutoMapper;
using Raven.Client;
using RavenDbNorthwind.Db;
using ShortBus;

namespace RavenDbNorthwind.Features.Products
{
    public class ShowProductQueryHandler : IQueryHandler<ShowProductQuery, ProductModel>
    {
        private readonly IDocumentSession session;

        public ShowProductQueryHandler(IDocumentSession session)
        {
            this.session = session;
        }

        public ProductModel Handle(ShowProductQuery request)
        {
            var product = session.Load<Product>(request.Id);

            return Mapper.Map<ProductModel>(product);
        }
    }
}