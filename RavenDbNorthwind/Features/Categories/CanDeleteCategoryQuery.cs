using ShortBus;

namespace RavenDbNorthwind.Features.Categories
{
    public class CanDeleteCategoryQuery : IQuery<CanDeleteCategoryModel>
    {
        public string Id { get; set; }
    }
}