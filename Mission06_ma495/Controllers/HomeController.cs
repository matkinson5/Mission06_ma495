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
        private readonly ILogger<HomeController> _logger;
        private MovieSubmissionsContext theContext { get; set; }
            

        public HomeController(ILogger<HomeController> logger, MovieSubmissionsContext Submission)
        {
            _logger = logger;
            theContext = Submission;
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
                theContext.Add(ar);
                theContext.SaveChanges();
                return View("Confirmation", ar);
            }
            else
            {
                return View(ar);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
