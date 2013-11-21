using System.Web.Mvc;
using ShortBus;

namespace RavenDbNorthwind.Features.Orders
{
    public class OrdersController : Controller
    {
        private readonly IMediator mediator;

        public OrdersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        //
        // GET: /Orders/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Orders/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Orders/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Orders/Create
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
        // GET: /Orders/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Orders/Edit/5
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
        // GET: /Orders/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Orders/Delete/5
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
