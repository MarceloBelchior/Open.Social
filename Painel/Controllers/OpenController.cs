﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Painel.Controllers
{
    public class OpenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}