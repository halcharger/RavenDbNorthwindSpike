using Raven.Client;
using RavenDbNorthwind.Db;
using ShortBus;

namespace RavenDbNorthwind.Features.Categories
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