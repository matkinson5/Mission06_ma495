using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission06_ma495.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

//last updated 2/21/2023

namespace Mission06_ma495.Controllers
{
    public class HomeController : Controller
    {

        private MovieSubmissionsContext MovieContext { get; set; }
            

        public HomeController( MovieSubmissionsContext Submission)
        {

            MovieContext = Submission;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MyPodcasts()
        {
                return View();
           
        }

        [HttpGet]
        public IActionResult MovieApplication()
        {
            ViewBag.Categories= MovieContext.Categories.ToList();
            return View("MovieApplication", new ApplicationResponse());
        }

        [HttpPost]
        public IActionResult MovieApplication(ApplicationResponse ar) //send in a movie to add 
        {
            if (ModelState.IsValid)
            {
                MovieContext.Add(ar);
                MovieContext.SaveChanges();
                return View("Confirmation", ar);
            }
            else
            {
                ViewBag.Categories = MovieContext.Categories.ToList();
                return View(ar);
            }
        }

        [HttpGet]

        public IActionResult MovieList() //show the list of moview
        {
            var movies = MovieContext.responses
                .Include(x => x.Category)
                .ToList();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit (int id)
        {
            ViewBag.Categories = MovieContext.Categories.ToList();

            var application = MovieContext.responses.Single(x => x.MovieId == id);

            return View("MovieApplication", application);
        }

        [HttpPost] //save the edits made to a given movie

        public IActionResult Edit (ApplicationResponse app)
        {
            MovieContext.Update(app);
            MovieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]

        public IActionResult Delete (int id)
        {
            ViewBag.Categories = MovieContext.Categories.ToList();

            var movie = MovieContext.responses.Single(x => x.MovieId == id);
            return View(movie);
        }

        [HttpPost] //delete the movie and send the user back to the list of moview

        public IActionResult Delete (ApplicationResponse ar)
        {
            MovieContext.responses.Remove(ar);
            MovieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

    }
}
