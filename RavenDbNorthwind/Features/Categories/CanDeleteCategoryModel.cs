namespace RavenDbNorthwind.Features.Categories
{
    public class CanDeleteCategoryModel
    {
        public bool CanDelete { get; set; }
        public string ReasonCannotDelete { get; set; }
    }
}