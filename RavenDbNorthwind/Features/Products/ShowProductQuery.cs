using ShortBus;

namespace RavenDbNorthwind.Features.Products
{
    public class ShowProductQuery : IQuery<ShowProductModel>
    {
        public string Id { get; set; }
    }
}