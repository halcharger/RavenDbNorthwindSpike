using System.Collections.Generic;
using System.Linq;
using Raven.Client;
using RavenDbNorthwind.Db;
using ShortBus;

namespace RavenDbNorthwind.Features.Categories
{
    public class ListCategoriesQueryHandler : IQueryHandler<ListCategoriesQuery, IEnumerable<Category>>
    {
        private readonly IDocumentSession session;

        public ListCategoriesQueryHandler(IDocumentSession session)
        {
            this.session = session;
        }

        public IEnumerable<Category> Handle(ListCategoriesQuery request)
        {
            return session.Query<Category>().ToList();
        }
    }
}