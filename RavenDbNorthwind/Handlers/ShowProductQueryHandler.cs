using AutoMapper;
using Raven.Client;
using RavenDbNorthwind.Models.Db;
using RavenDbNorthwind.Models.View;
using RavenDbNorthwind.Queries;
using ShortBus;

namespace RavenDbNorthwind.Handlers
{
    public class ShowProductQueryHandler : IQueryHandler<ShowProductQuery, ProductViewModel>
    {
        private readonly IDocumentSession session;

        public ShowProductQueryHandler(IDocumentSession session)
        {
            this.session = session;
        }

        public ProductViewModel Handle(ShowProductQuery request)
        {
            var product = session.Load<Product>(request.Id);

            return Mapper.Map<ProductViewModel>(product);
        }
    }
}