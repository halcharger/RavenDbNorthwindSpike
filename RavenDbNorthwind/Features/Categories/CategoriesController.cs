using System.Web.Mvc;
using ShortBus;

namespace RavenDbNorthwind.Features.Categories
{
    public class CategoriesController : Controller
    {
        private readonly IMediator mediator;

        public CategoriesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        //
        // GET: /Categories/
        public ActionResult Index()
        {
            var response = mediator.Request(new ListCategoriesQuery());
            return View(response.Data);
        }

        //
        // GET: /Categories/Details/5
        public ActionResult Details(string id)
        {
            var response = mediator.Request(new ShowCategoryQuery {Id = id});
            return View(response.Data);
        }

        //
        // GET: /Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Categories/Create
        [HttpPost]
        public ActionResult Create(CreateCategoryModel model)
        {
            try
            {
                mediator.Send(new CreateCategoryCommand {Model = model});

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Categories/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Categories/Edit/5
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
        // GET: /Categories/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Categories/Delete/5
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
