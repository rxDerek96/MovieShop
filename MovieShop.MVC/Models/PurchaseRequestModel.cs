using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Models
{
    public class PurchaseRequestModel
    {
        public int userId;
        public string purchaseNumber;
        public double totalPrice;
        public string purchaseDateTime;
        public int movieId;
    }
}
