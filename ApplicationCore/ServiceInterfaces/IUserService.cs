﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IUserService
    {
        Task<bool> IsMoviePurchased(PurchaseRequestModel purchaseRequest);
        Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel userRegisterRequestModel);
        Task<UserLoginResponseModel> Login(string email, string password);

        // delete
        // EditUser
        // Change Password
        // Purchase Movie
        Task PurchaseMovie(PurchaseRequestModel model);
        // Favorite Movie
        Task LikeMovie(FavoriteRequestModel model);
        // Add Review
        // Get All Purchased Movies
        Task<List<MovieCardResponseModel>> GetUserPurchasedMovies(int userId);
        // Get All Favorited Movies
        Task<List<MovieCardResponseModel>> GetUserFavoriteMovies(int userId);
        // Edit Review
        // Remove Favorite
        // Get User Details
        Task<UserProfileResponseModel> GetUserProfile(int userId);

        Task<UserProfileResponseModel> EditUserProfile(UserProfileResponseModel userProfileResponseModel);
    }
}