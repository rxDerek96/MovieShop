using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class UserController : Controller
    {
        public IActionResult purchase()
        {
            return View();
        }
        public IActionResult favorite()
        {
            return View();
        }
        public IActionResult unfavorite()
        {
            return View();
        }
        public IActionResult review()
        {
            return View();
        }
    }
}
