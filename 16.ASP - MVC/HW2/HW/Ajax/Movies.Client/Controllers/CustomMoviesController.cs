using Movies.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movies.Client.Controllers
{
    public class CustomMoviesController : Controller
    {
        public ActionResult Index()
        {
            MoviesDbEntities context = new MoviesDbEntities();

            return View(context.Movies.ToList());
        }

        public ActionResult Create()
        {

            return PartialView("_CreateMovie");
        }

        public ActionResult CreateSave(Movie movie, string submit)
        {
            MoviesDbEntities context = new MoviesDbEntities();

            if (submit == "Create")
            {
                context.Movies.Add(movie);
                context.SaveChanges();
            }

            return PartialView("_MoviesResult", context.Movies.ToList());
        }

        public ActionResult Edit(int MovieId)
        {
            MoviesDbEntities context = new MoviesDbEntities();

            var result = context.Movies.Find(MovieId);

            return PartialView("_EditMovie", result);
        }

        public ActionResult EditSave(Movie movie, string submit)
        {
            MoviesDbEntities context = new MoviesDbEntities();

            if (submit == "Save")
            {
                var movieInDb = context.Movies.Find(movie.MovieId);

                movieInDb.Title = movie.Title;
                movieInDb.MaleActorName = movie.MaleActorName;
                movieInDb.MaleActorAge = movie.MaleActorAge;
                movieInDb.FemaleActorName = movie.FemaleActorName;
                movieInDb.FemaleActorAge = movieInDb.FemaleActorAge;
                movieInDb.Director = movie.Director;
                movieInDb.StudioName = movie.StudioName;
                movieInDb.StudioAddress = movie.StudioAddress;
                movieInDb.Year = movie.Year;

                context.SaveChanges();
            }

            return PartialView("_MoviesResult", context.Movies.ToList());
        }

        public ActionResult Delete(int MovieId)
        {
            MoviesDbEntities context = new MoviesDbEntities();

            var result = context.Movies.Find(MovieId);

            return PartialView("_DeleteMovie", result);
        }

        public ActionResult DeleteSave(int MovieId, string submit)
        {
            MoviesDbEntities context = new MoviesDbEntities();

            if (submit == "Delete")
            {
                var movieInDb = context.Movies.Find(MovieId);
                context.Movies.Remove(movieInDb);
                context.SaveChanges();
            }

            return PartialView("_MoviesResult", context.Movies.ToList());
        }

    }
}
