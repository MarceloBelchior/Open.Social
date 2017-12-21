﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Open.Social.UI.Areas.Controllers
{
    
    [AllowAnonymous]
    [Area("OAuth")]
    [Route("OAuth/[controller]/[action]")]
    public class LoginController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Login(string login, string senha)
        {
            
            return View();
        }

        //[HttpPost]
        //[Route("Autenticacao")]
        public async Task Autenticacao(object entity)
        {
            //    await _timeSheetManager.CreateAsync(entity);
        }



    }
}