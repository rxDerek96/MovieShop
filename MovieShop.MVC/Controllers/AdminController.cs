﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult movie()
        {
            return View();
        }
        public IActionResult purchases()
        {
            return View();
        }
    }
}
