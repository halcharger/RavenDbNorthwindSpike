using AutoMapper;
using Raven.Client;
using RavenDbNorthwind.Db;
using ShortBus;

namespace RavenDbNorthwind.Features.Categories
{
    public class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand>
    {
        private readonly IDocumentSession session;

        public CreateCategoryCommandHandler(IDocumentSession session)
        {
            this.session = session;
        }

        public void Handle(CreateCategoryCommand message)
        {
            var category = Mapper.Map<Category>(message.Model);

            session.Store(category);
            session.SaveChanges();
        }
    }
}