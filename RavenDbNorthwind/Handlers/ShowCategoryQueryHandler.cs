using Raven.Client;
using RavenDbNorthwind.Models.Db;
using RavenDbNorthwind.Queries;
using ShortBus;

namespace RavenDbNorthwind.Handlers
{
    public class ShowCategoryQueryHandler : IQueryHandler<ShowCategoryQuery, Category>
    {
        private readonly IDocumentSession session;

        public ShowCategoryQueryHandler(IDocumentSession session)
        {
            this.session = session;
        }
        
        public Category Handle(ShowCategoryQuery request)
        {
            return session.Load<Category>(request.Id);
        }
    }
}