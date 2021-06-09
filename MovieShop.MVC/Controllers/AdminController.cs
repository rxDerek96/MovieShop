using ApplicationCore.Models.Request;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IUserService _userService;

        public AdminController(IUserService userService, IMovieService movieService)
        {
            _userService = userService;
            _movieService = movieService;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> CreateMovie()
        {
            return View();
        }
        public IActionResult purchases()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateMovie(MovieCreateRequestModel movieCreateRequest)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var createdMovie = await _movieService.CreateMovie(movieCreateRequest);
            return RedirectToAction("Index");
        }
    }
}
