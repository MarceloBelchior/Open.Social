﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Open.Social.UI.Models;

namespace Open.Social.UI.Controllers
{

    public class HomeController : BaseController
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
           

            return View();
        }

        public IActionResult Footer()
        {
            return View();
        }
        public IActionResult TopMenu()
        {
            return View();
        }

        public IActionResult Contact()
        {
           
            return View();
        }
        public IActionResult MainMenu()
        {
            return View();
        }
        public IActionResult Avatar()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
