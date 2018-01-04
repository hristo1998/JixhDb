using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JixhDb.Data;
using JixhDb.Models.BindingModels.Review;
using JixhDb.Models.EntittyModels;
using JixhDb.Web.Services;
using Microsoft.AspNet.Identity;

namespace JixhDb.Web.Areas.Reviews.Controllers
{
    [RouteArea("Reviews")]
    public class ReviewsController : Controller
    {
        private ReviewService _service;

        public ReviewsController()
        {
            this._service = new ReviewService();
        } 
            

        // GET: Reviews/Details/5
        [Route("Details/{id:int}")]
        public ActionResult Details(int id)
        {
            var review = this._service.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // GET: Reviews/Create
        [HttpGet, Route("New/{id:int}")]
        public ActionResult Create(int id)
        {
            return View(new NewReviewBindingModel() {MovieId = id});
        }

        // POST: Reviews/Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("New/{id:int}")]
        public ActionResult Create([Bind(Include = "Text,MovieId")] NewReviewBindingModel review)
        {
            if (ModelState.IsValid)
            {
                var loggedUserId = User.Identity.GetUserId();
                var reviewId = this._service.Add(review, loggedUserId);
                return RedirectToAction("Details", new { id = reviewId });
            }

            return View(review);
        }

        //// GET: Reviews/Reviews/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Review review = db.Reviews.Find(id);
        //    if (review == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(review);
        //}

        //// POST: Reviews/Reviews/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Text,DateTime")] Review review)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(review).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(review);
        //}

        //// GET: Reviews/Reviews/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Review review = db.Reviews.Find(id);
        //    if (review == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(review);
        //}

        //// POST: Reviews/Reviews/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Review review = db.Reviews.Find(id);
        //    db.Reviews.Remove(review);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
