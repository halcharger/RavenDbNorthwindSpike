using ShortBus;

namespace RavenDbNorthwind.Features.Categories
{
    public class CreateCategoryCommand : ICommand
    {
        public CreateCategoryModel Model { get; set; }
    }
}