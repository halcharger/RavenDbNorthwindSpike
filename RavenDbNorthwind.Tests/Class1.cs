using System.Linq;
using NUnit.Framework;
using Raven.Client.Document;
using RavenDbNorthwind.Models.Db;

namespace RavenDbNorthwind.Tests
{
    [TestFixture]
    public class Class1
    {
        [Test, Explicit]
        public void UpdateSupplierClrType()
        {
            var store = new DocumentStore {Url = "http://localhost:8080", DefaultDatabase = "Northwind"};
            store.Initialize();
            using (var session = store.OpenSession())
            {
                foreach (var supplier in session.Query<Supplier>().ToList())
                {
                    session.Advanced.GetMetadataFor(supplier);
                }
                session.SaveChanges();
            }
        }
    }
}
