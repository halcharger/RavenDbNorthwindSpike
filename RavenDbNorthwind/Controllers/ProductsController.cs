using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Raven.Client;
using RavenDbNorthwind.Models.Db;
using RavenDbNorthwind.Models.View;

namespace RavenDbNorthwind.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IDocumentSession RavenSession;

        public ProductsController(IDocumentSession ravenSession)
        {
            RavenSession = ravenSession;
        }

        //
        // GET: /Products/
        public ActionResult Index()
        {
            var dbProducts = RavenSession.Query<Product>()
                                       .Customize(q => q.Include<Category>(c => c.Name))
                                       .Customize(q => q.Include<Supplier>(s => s.Name))
                                       .ToList();

            var viewProducts = dbProducts.Select(Mapper.Map<ProductViewModel>);

            return View(viewProducts);
        }

        //
        // GET: /Products/Details/5
        public ActionResult Details(string id)
        {
            var product = RavenSession.Load<Product>(id);
            return View(product);
        }

        //
        // GET: /Products/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Products/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Products/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
