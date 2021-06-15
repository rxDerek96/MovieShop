using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;
        public MoviesController(IMovieService movieService, IGenreService genreService)
        {
            _movieService = movieService;
            _genreService = genreService;
        }
        public async Task<IActionResult> Details(int id)
        {
            var movie = await _movieService.GetMovieDetailsById(id);
            return View(movie);
        }
        public async Task<IActionResult> toprated()
        {
            var movies = await _movieService.GetTopRatedMovies();

            return View(movies);
        }
        public async Task<IActionResult> toprevenue()
        {
            var movies = await _movieService.GetTopRevenueMovies();

            return View(movies);
        }
        public async Task<IActionResult> Genre(int id)
        {
            var moviecards = await _genreService.GetMoviesByGenreId(id);
            return View(moviecards);
        }
    }
   
}
