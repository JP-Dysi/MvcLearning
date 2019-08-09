using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcLearning.Models;

namespace MvcLearning.Controllers
{
    public class MoviesController : Controller
    {
        private MovieDbContext db = new MovieDbContext();

        // GET: Movies
        public ActionResult Index(string genreString, string searchString)
        {
			var genreQuery = from d in db.Movies orderby d.Genre select d.Genre;
			var genreList = new List<string>();
			genreList.AddRange(genreQuery.Distinct());

			ViewBag.movieGenre = new SelectList(genreList);

			var movies = from m in db.Movies select m;

			if(!string.IsNullOrEmpty(searchString))
			{
				movies = movies.Where(m => m.Title.Contains(searchString));
			}

			if(!string.IsNullOrEmpty(genreString))
			{
				movies = movies.Where(m => m.Genre == genreString);
			}

            return View(movies);
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieModel movieModel = db.Movies.Find(id);
            if (movieModel == null)
            {
                return HttpNotFound();
            }
            return View(movieModel);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,ReleaseDate,Genre,Price,Rating")] MovieModel movieModel)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movieModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movieModel);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieModel movieModel = db.Movies.Find(id);
            if (movieModel == null)
            {
                return HttpNotFound();
            }
            return View(movieModel);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,ReleaseDate,Genre,Price,Rating")] MovieModel movieModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movieModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movieModel);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieModel movieModel = db.Movies.Find(id);
            if (movieModel == null)
            {
                return HttpNotFound();
            }
            return View(movieModel);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MovieModel movieModel = db.Movies.Find(id);
            db.Movies.Remove(movieModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
