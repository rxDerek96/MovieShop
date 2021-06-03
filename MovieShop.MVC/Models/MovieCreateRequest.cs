using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Models
{
    public class MovieCreateRequest
    {
        public int id;
        public string title;
        public string overview;
        public string tagline;
        public double revenue;
        public double budget;
        public string imdbUrl;
        public string tmdbUrl;
        public string posterUrl;
        public string backdropUrl;
        public string originalLanguage;
        public string releaseDate;
        public int runTime;
        public double price;
        public Genre genres;

    }
}
