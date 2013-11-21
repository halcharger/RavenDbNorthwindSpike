using AutoMapper;
using Raven.Client;
using RavenDbNorthwind.Db;
using ShortBus;

namespace RavenDbNorthwind.Features.Categories
{
    public class EditCategoryCommandHandler : ICommandHandler<EditCategoryCommand>
    {
        private readonly IDocumentSession session;

        public EditCategoryCommandHandler(IDocumentSession session)
        {
            this.session = session;
        }

        public void Handle(EditCategoryCommand message)
        {
            var category = Mapper.Map<Category>(message.Model);

            session.Store(category);
            session.SaveChanges();
        }
    }
}