using System;
namespace ApplicationCore.Models.Request
{
    public class FavoriteRequestModel
    {

        public int UserId { get; set; }
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string PosterUrl { get; set; }
    }
}