﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class MoviesController : Controller
    {
        
        public IActionResult Details(int id)
        {
            return View();
        }
        public IActionResult toprated()
        {
            return View();
        }
        public IActionResult toprevenue()
        {
            return View();
        }
        public IActionResult genre(int genreid)
        {
            return View();
        }
    }
   
}
