using ShortBus;

namespace RavenDbNorthwind.Features.Products
{
    public class ShowProductQuery : IQuery<ProductModel>
    {
        public string Id { get; set; }
    }
}