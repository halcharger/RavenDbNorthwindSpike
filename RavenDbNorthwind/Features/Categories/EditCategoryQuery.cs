using ShortBus;

namespace RavenDbNorthwind.Features.Categories
{
    public class EditCategoryQuery : IQuery<EditCategoryModel>
    {
        public string Id { get; set; }
    }
}