using ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;

public class PurchaseResponseModel
{
    public int UserId { get; set; }
    public List<PurchasedMovieResponseModel> PurchasedMovies { get; set; }

    public class PurchasedMovieResponseModel : MovieCardResponseModel
    {
        public DateTime PurchaseDateTime { get; set; }
    }
}