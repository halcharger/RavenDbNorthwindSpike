using AutoMapper;
using Raven.Client;
using RavenDbNorthwind.Db;
using RavenDbNorthwind.Infrastructure;
using ShortBus;

namespace RavenDbNorthwind.Features.Categories
{
    public class EditCategoryQueryHandler : RavenDbSessionEnabledHandler, IQueryHandler<EditCategoryQuery, EditCategoryModel>
    {
        public EditCategoryQueryHandler(IDocumentSession session) : base(session)
        {
        }

        public EditCategoryModel Handle(EditCategoryQuery request)
        {
            var category = session.Load<Category>(request.Id);

            return Mapper.Map<EditCategoryModel>(category);
        }
    }
}