using System.Web.Mvc;
using Raven.Client;
using RavenDbNorthwind.Models.Db;
using RavenDbNorthwind.Queries;
using ShortBus;

namespace RavenDbNorthwind.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IDocumentSession RavenSession;
        private readonly IMediator mediator;

        public ProductsController(IDocumentSession ravenSession, IMediator mediator)
        {
            RavenSession = ravenSession;
            this.mediator = mediator;
        }

        //
        // GET: /Products/
        public ActionResult Index()
        {
            var response = mediator.Request(new ListProductsQuery());
            return View(response.Data);
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
