using RavenDbNorthwind.Db;
using ShortBus;

namespace RavenDbNorthwind.Features.Categories
{
    public class ShowCategoryQuery : IQuery<Category>
    {
        public string Id { get; set; }
    }
}