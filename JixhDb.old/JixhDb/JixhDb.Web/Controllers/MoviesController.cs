using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JixhDb.Data;
using JixhDb.Models.BindingModels.Movies;
using JixhDb.Models.EntittyModels;
using JixhDb.Models.ViewModels.Movies;
using JixhDb.Web.Attributes;
using JixhDb.Web.Services;

namespace JixhDb.Web.Controllers
{
    [MyAuthorize(Roles = "Admin")]
    [RoutePrefix("Movies")]
    public class MoviesController : Controller
    {
        private MoviesService _service;

        public MoviesController()
        {
            this._service = new MoviesService();
        }

        [HttpGet]
        [Route]
        [AllowAnonymous]
        public ActionResult GetMovies()
        {
            ViewBag.Category = "Lates Movies";
            return View(this._service.Movies());
        }

        [HttpGet]
        [Route("{category:alpha}")]
        [AllowAnonymous]
        public ActionResult Categories(string category)
        {

            var movies = this._service.Movies(category);

            ViewBag.Category = movies.Any() ? category : "No movies in this category yet :/";
           
            return View(movies);
        }

        [HttpGet]
        [Route("{id:int}")]
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var movie = this._service.Movie(id);

            if (movie == null)
            {
                return HttpNotFound();
            }
            
            return View(movie);
        }

        [HttpGet]
        [Route("new")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("new")]
        public ActionResult Create([Bind(Include = "CoverUrl,Title,TrailerLink,ReleaseDate,Duration,Director,Writers,Cast,Storyline,Rating")] NewMovieBindingModel movie)  
        {
            if (ModelState.IsValid)
            {
                this._service.Add(movie);
                return RedirectToAction("GetMovies");
            }

            return View(movie);
        }

        // GET: Movies/Edit/5
        [HttpGet]
        [Route("Edit/{id:int}")]
        public ActionResult Edit(int id)
        {
            var movie = this._service.Movie(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit/{id:int}")]
        public ActionResult Edit([Bind(Include = "Id,CoverUrl,Title,TrailerLink,ReleaseDate,Duration,Director,Writers,Cast,Storyline,Rating")] EditMovieBidingModel movie)
        {
            if (ModelState.IsValid)
            {
                this._service.Modify(movie);
                
                return RedirectToAction("GetMovies");
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        [HttpGet]
        [Route("Delete/{id:int}")]
        public ActionResult Delete(int id)
        {

            var movie = this._service.Movie(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Delete/{id:int}")]
        public ActionResult DeleteConfirmed(int id)
        {
            this._service.Delete(id);
            return RedirectToAction("GetMovies");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        this._service.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
