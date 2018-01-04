using JixhDb.Models.ViewModels.Category;

namespace JixhDb.Web.Controllers
{
    using System.Data.Entity;
    using System.Net;
    using System.Web.Mvc;
    using JixhDb.Models.EntittyModels;
    using JixhDb.Web.Attributes;
    using JixhDb.Web.Services;
    using JixhDb.Models.BindingModels.Category;



    [MyAuthorize(Roles = "Admin")]
    [RoutePrefix("Category")]
    public class CategoriesController : Controller
    {
        private CategoriesService _service;

        public CategoriesController()
        {
            this._service = new CategoriesService();
        }
        // GET: Categories
        [HttpGet, Route]
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(this._service.Categories());
        }


        // GET: Categories/Create
        [HttpGet, Route("new")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("new")]
        public ActionResult Create([Bind(Include = "Id,Name")] NewCategoryBindingModel category)
        {
            if (ModelState.IsValid)
            {
                this._service.Add(category);
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Categories/Edit/5
        [HttpGet]
        [Route("Edit/{id:int}")]
        public ActionResult Edit(int id)
        {

            var category = this._service.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit/{id:int}")]
        public ActionResult Edit([Bind(Include = "Id,Name")] CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                this._service.Modify(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        [HttpGet, Route("Delete/{id:int}")]
        public ActionResult Delete(int id)
        {

            var category = this._service.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Delete/{id:int}")]
        public ActionResult DeleteConfirmed(int id)
        {
            this._service.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
