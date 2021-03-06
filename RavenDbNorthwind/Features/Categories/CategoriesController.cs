﻿using System.Web.Mvc;
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
        public ActionResult Edit(string id)
        {
            var response = mediator.Request(new EditCategoryQuery {Id = id});
            return View(response.Data);
        }

        //
        // POST: /Categories/Edit/5
        [HttpPost]
        public ActionResult Edit(EditCategoryModel model)
        {
            try
            {
                mediator.Send(new EditCategoryCommand {Model = model});

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Categories/Delete/5
        public ActionResult Delete(string id)
        {
            try
            {
                var response = mediator.Request(new CanDeleteCategoryQuery {Id = id});

                if (response.Data.CanDelete)
                    mediator.Send(new DeleteCategoryCommand {Id = id});
                else
                    return View("DeleteError", (object)response.Data.ReasonCannotDelete);
            }
            catch
            {
                
            }
            return RedirectToAction("Index");
        }
    }
}
