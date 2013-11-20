using AutoMapper;
using RavenDbNorthwind.Models.Db;
using RavenDbNorthwind.Models.View;

namespace RavenDbNorthwind
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.CreateMap<Product, ProductViewModel>();
        }
    }
}