using Raven.Client;

namespace RavenDbNorthwind.Infrastructure
{
    public class RavenDbSessionEnabledHandler
    {
        protected readonly IDocumentSession session;

        public RavenDbSessionEnabledHandler(IDocumentSession session)
        {
            this.session = session;
        }
    }
}