using System.Collections.Generic;
using RavenDbNorthwind.Models.Db;
using ShortBus;

namespace RavenDbNorthwind.Queries
{
    public class ShowCategoryQuery : IQuery<Category>
    {
        public string Id { get; set; }
    }
}