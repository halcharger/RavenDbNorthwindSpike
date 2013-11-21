using System;
using System.Linq;
using Raven.Client;
using Raven.Client.Linq;
using RavenDbNorthwind.Db;
using RavenDbNorthwind.Infrastructure;
using ShortBus;

namespace RavenDbNorthwind.Features.Categories
{
    public class CanDeleteCategoryQueryHandler : RavenDbSessionEnabledHandler, IQueryHandler<CanDeleteCategoryQuery, CanDeleteCategoryModel>
    {
        public CanDeleteCategoryQueryHandler(IDocumentSession session) : base(session)
        {
        }

        public CanDeleteCategoryModel Handle(CanDeleteCategoryQuery request)
        {
            var refedProducts = session.Query<Product>().Where(p => p.Category == request.Id).ToList();

            if (refedProducts.Count == 0) 
                return new CanDeleteCategoryModel {CanDelete = true};
            
            return new CanDeleteCategoryModel
            {
                CanDelete = false,
                ReasonCannotDelete = "The following products are currently associated with this category: " + String.Join(", ", refedProducts.Select(p => p.Name))
            };
        }
    }
}