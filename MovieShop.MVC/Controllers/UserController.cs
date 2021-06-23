using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IUserService _userService;
        private readonly IMovieService _movieService;


        public UserController(ICurrentUserService currentUserService, IUserService userService, IMovieService movieService)
        {
            _currentUserService = currentUserService;
            _userService = userService;
            _movieService = movieService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> PurchasedMovies()
        {

            var userId = _currentUserService.UserId;
            // get the user id
            //
            // make a request to the database and get info from purchase table 
            // select * from Purchase where userid = @getfromcookie
            var purchasedMovies = await _userService.GetUserPurchasedMovies(userId);

            return View(purchasedMovies);
        }
        public async Task<IActionResult> FavoriteMovies()
        {

            var userId = _currentUserService.UserId;
            // get the user id
            //
            // make a request to the database and get info from favorite table 
            var FavoriteMovies = await _userService.GetUserFavoriteMovies(userId);

            return View(FavoriteMovies);
        }


        [HttpGet]
        public async Task<IActionResult> PurchaseMovie(int id)
        {
            var movie = await _movieService.GetMovieDetailsById(id);
            var purchase = new PurchaseRequestModel
            {
                UserId = _currentUserService.UserId,
                Title=movie.Title,
                PosterUrl=movie.PosterUrl,
                Price=movie.Price,
                MovieId=movie.Id
                
            };
            return View(purchase);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PurchaseMovie(PurchaseRequestModel purchase)
        {
            purchase.UserId = _currentUserService.UserId;
            await _userService.PurchaseMovie(purchase);
            return RedirectToAction("PurchasedMovies");
        }


        public async Task<IActionResult> LikeMovie(int id)
        {
            var movie = await _movieService.GetMovieDetailsById(id);
            var like = new FavoriteRequestModel
            {
                UserId = _currentUserService.UserId,
                Title = movie.Title,
                MovieId = movie.Id,
                PosterUrl = movie.PosterUrl,
            };
            return View(like);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> LikeMovie(FavoriteRequestModel favorite)
        {
            favorite.UserId = _currentUserService.UserId;
            await _userService.LikeMovie(favorite);
            return RedirectToAction("FavoriteMovies");
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ViewProfile()
        {
            var userId = _currentUserService.UserId;
            var userProfile = await _userService.GetUserProfile(userId);

            return View(userProfile);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var userId = _currentUserService.UserId;
            var userProfile = await _userService.GetUserProfile(userId);

            return View(userProfile);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditProfile(UserProfileResponseModel model)
        {
            model.Id = _currentUserService.UserId;
            if (ModelState.IsValid)
            {
                //save to database
                await _userService.EditUserProfile(model);
                // redirect to Login 
            }
            // take name, dob, email, pasword from view and save it to database
            return RedirectToAction("ViewProfile");
        }
    }
}
