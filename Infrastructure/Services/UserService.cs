using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;


namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMovieService _movieService;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IFavoriteRepository _favoriteRepository;
        public UserService(IUserRepository userRepository, ICurrentUserService currentUserService,  IMovieService movieService,IPurchaseRepository purchaseRepository, IFavoriteRepository favoriteRepository)
        {
            _userRepository = userRepository;
            _currentUserService = currentUserService;
            _movieService = movieService;
            _purchaseRepository = purchaseRepository;
            _favoriteRepository = favoriteRepository;
        }

        public async Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel userRegisterRequestModel)
        {
            // first we need to check the email does not exists in our database

            var dbUser = await _userRepository.GetUserByEmail(userRegisterRequestModel.Email);

            if (dbUser != null)
                // email exists in db
                throw new Exception("User already exists, please try to login");

            // generate a unique Salt
            var salt = CreateSalt();

            // hash the password with userRegisterRequestModel.Password + salt from above step
            var hashedPassword = CreateHashedPassword(userRegisterRequestModel.Password, salt);

            // call the user repository to save the user Info

            var user = new User
            {
                FirstName = userRegisterRequestModel.FirstName,
                LastName = userRegisterRequestModel.LastName,
                Email = userRegisterRequestModel.Email,
                DateOfBirth = userRegisterRequestModel.DateOfBirth,
                Salt = salt,
                HashedPassword = hashedPassword
            };

            var createdUser = await _userRepository.Add(user);

            // convert the returned user entity to UserRegisterResponseModel

            var response = new UserRegisterResponseModel
            {
                Id = createdUser.Id,
                FirstName = createdUser.FirstName,
                LastName = createdUser.LastName,
                Email = createdUser.Email
            };

            return response;
        }

        public async Task<UserLoginResponseModel> Login(string email, string password)
        {
            // go to database and get the user info -- row by email
            var user = await _userRepository.GetUserByEmail(email);

            if (user == null)
            {
                // return null
                return null;
            }

            // get the password from UI and salt from above step from database and call CreateHashedPassword method

            var hashedPassword = CreateHashedPassword(password, user.Salt);

            if (hashedPassword == user.HashedPassword)
            {
                // user entered correct password
                var Rolelist = new List<string>();
                foreach(var role in user.Roles)
                {
                    Rolelist.Add(role.Name);
                }
                var loginResponseModel = new UserLoginResponseModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Roles=Rolelist
                };
                return loginResponseModel;
            }

            return null;
        }

        private string CreateSalt()
        {
            var randomBytes = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            return Convert.ToBase64String(randomBytes);
        }

        private string CreateHashedPassword(string password, string salt)
        {
            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password,
                Convert.FromBase64String(salt),
                KeyDerivationPrf.HMACSHA512,
                10000,
                256 / 8));
            return hashed;
        }
        public async Task<List<MovieCardResponseModel>> GetUserPurchasedMovies(int id)
        {
            var user = await _userRepository.GetById(id);

            var purchedMovieCardList = new List<MovieCardResponseModel>();
            foreach (var usermovie in user.Purchases)
            {
                purchedMovieCardList.Add(new MovieCardResponseModel
                {
                    Id = usermovie.MovieId,
                    PosterUrl = usermovie.Movie.PosterUrl,
                    ReleaseDate = usermovie.Movie.ReleaseDate.GetValueOrDefault(),
                    Title = usermovie.Movie.Title
                });
            }

            return purchedMovieCardList;
        }
        public async Task<List<MovieCardResponseModel>> GetUserFavoriteMovies(int id)
        {
            var user = await _userRepository.GetById(id);

            var favoriteMovieCardList = new List<MovieCardResponseModel>();
            foreach (var usermovie in user.Favorites)
            {
                favoriteMovieCardList.Add(new MovieCardResponseModel
                {
                    Id = usermovie.MovieId,
                    PosterUrl = usermovie.Movie.PosterUrl,
                    ReleaseDate = usermovie.Movie.ReleaseDate.GetValueOrDefault(),
                    Title = usermovie.Movie.Title
                });
            }

            return favoriteMovieCardList;
        }
        public async Task<UserProfileResponseModel> GetUserProfile(int userId)
        {

            var user = await _userRepository.GetById(userId);
            var userProfile = new UserProfileResponseModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth.GetValueOrDefault(),
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                LastLoginDateTime = user.LastLoginDateTime.GetValueOrDefault(DateTime.Now)
            };



            return userProfile;
        }
        public async Task<UserProfileResponseModel> EditUserProfile(UserProfileResponseModel userProfileResponseModel)
        {
            var user = await _userRepository.GetById(userProfileResponseModel.Id);

            if (user == null)
            {
                // return null
                return null;
            }

            user.Id = userProfileResponseModel.Id;
            user.FirstName = userProfileResponseModel.FirstName;
            user.LastName = userProfileResponseModel.LastName;
            user.Email = userProfileResponseModel.Email;
            user.PhoneNumber = userProfileResponseModel.PhoneNumber;
            user.LastLoginDateTime = userProfileResponseModel.LastLoginDateTime;

            await _userRepository.Update(user);

            var response = new UserProfileResponseModel
            {
                Id = userProfileResponseModel.Id,
                FirstName = userProfileResponseModel.FirstName,
                LastName = userProfileResponseModel.LastName,
                Email = userProfileResponseModel.Email,
                PhoneNumber = userProfileResponseModel.PhoneNumber,
                LastLoginDateTime = userProfileResponseModel.LastLoginDateTime
            };

            return response;
        }
        public async Task<bool> IsMoviePurchased(PurchaseRequestModel purchaseRequest)
        {
            return await _purchaseRepository.GetExists(p =>
                p.UserId == purchaseRequest.UserId && p.MovieId == purchaseRequest.MovieId);
        }
        public async Task<bool> IsMovieLiked(FavoriteRequestModel favorite)
        {
            return await _favoriteRepository.GetExists(p =>
                p.UserId == favorite.UserId && p.MovieId == favorite.MovieId);
        }
        public async Task PurchaseMovie(PurchaseRequestModel purchaseRequest)
        {

            if (_currentUserService.UserId != purchaseRequest.UserId)
                throw new Exception("You are not Authorized to purchase");
            if (_currentUserService.UserId != null) purchaseRequest.UserId = _currentUserService.UserId;
            // See if Movie is already purchased.
            if (await IsMoviePurchased(purchaseRequest))
                throw new ConflictException("Movie already Purchased");
            // Get Movie Price from Movie Table
            var movie = await _movieService.GetMovieDetailsById(purchaseRequest.MovieId);
            purchaseRequest.TotalPrice = movie.Price;

            var purchase = new Purchase
            {
                UserId = purchaseRequest.UserId,
                PurchaseNumber = purchaseRequest.PurchaseNumber,
                TotalPrice= purchaseRequest.TotalPrice,
                PurchaseDateTime = purchaseRequest.PurchaseDateTime,
                MovieId = purchaseRequest.MovieId
            };
            await _purchaseRepository.Add(purchase);
        }
        public async Task LikeMovie(FavoriteRequestModel favorite)
        {

            if (_currentUserService.UserId != favorite.UserId)
                throw new Exception("You are not Authorized");
            if (_currentUserService.UserId != null) favorite.UserId = _currentUserService.UserId;
            // See if Movie is already liked.
            if (await IsMovieLiked(favorite))
                throw new ConflictException("Movie already Purchased");
            // Get Movie Price from Movie Table
            var movie = await _movieService.GetMovieDetailsById(favorite.MovieId);
            

            var request = new Favorite
            {
                UserId = favorite.UserId,
                MovieId = favorite.MovieId
            };
            await _favoriteRepository.Add(request);
        }

    }

}