using ApplicationCore.ServiceInterfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieShop.MVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService _movieService;

        public HomeController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            
            var movies = _movieService.GetTopRevenueMovies();
            //send the data to the view to display
            //1.passing the data from Controller to view using strongly typed models
            //2.viewbag
            //3.viewdata
            ViewBag.MoviesCount = movies.Count;
            ViewBag.PageTitle = "Top Revenue Movies";
            ViewData["MyCustomData"] = "Some Info";
            return View(movies);
        }
        public IActionResult TopMovies()
        {
            return View();
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
