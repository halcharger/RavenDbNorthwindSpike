using Raven.Abstractions.Commands;
using Raven.Client;
using RavenDbNorthwind.Infrastructure;
using ShortBus;

namespace RavenDbNorthwind.Features.Categories
{
    public class DeleteCategoryCommandHandler : RavenDbSessionEnabledHandler, ICommandHandler<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandHandler(IDocumentSession session) : base(session)
        {
        }

        public void Handle(DeleteCategoryCommand message)
        {
            session.Advanced.Defer(new DeleteCommandData{Key = message.Id});
            session.SaveChanges();
        }
    }
}