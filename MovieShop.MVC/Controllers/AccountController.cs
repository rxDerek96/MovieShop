using ApplicationCore.Models.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class AccountController : Controller
    {

        [HttpGet]
        public IActionResult Register()
        {
            // show a view with empty text boxes for name, dob, email. password

            return View();
        }

        [HttpPost]
        public IActionResult Register(UserRegisterRequestModel model)
        {
            // take name, dob, email, pasword from view and save it to database
            return View();
        }
    }
}