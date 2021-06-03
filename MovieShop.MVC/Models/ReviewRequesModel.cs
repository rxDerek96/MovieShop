using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Models
{
    public class ReviewRequesModel
    {
        public int userId;
        public int movieId;
        public string reviewText;
        public double rating;
    }
}
