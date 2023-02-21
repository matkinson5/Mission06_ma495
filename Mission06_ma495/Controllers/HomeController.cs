using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission06_ma495.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

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
            return View();
        }

        [HttpPost]
        public IActionResult MovieApplication(ApplicationResponse ar)
        {
            if (ModelState.IsValid)
            {
                MovieContext.Add(ar);
                MovieContext.SaveChanges();
                return View("Confirmation", ar);
            }
            else
            {
                return View(ar);
            }
        }

        [HttpGet]

        public IActionResult MovieList()
        {
            var movies = MovieContext.responses.ToList();
            return View(movies);
        }

    }
}
