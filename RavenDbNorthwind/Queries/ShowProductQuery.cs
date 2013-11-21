using RavenDbNorthwind.Models.View;
using ShortBus;

namespace RavenDbNorthwind.Queries
{
    public class ShowProductQuery : IQuery<ProductViewModel>
    {
        public string Id { get; set; }
    }
}