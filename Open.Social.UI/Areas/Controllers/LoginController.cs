using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Open.Social.UI.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using Open.Social.Utils.JWT;
using Open.Social.UI.Controllers;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace Open.Social.UI.Areas.Controllers
{

    [AllowAnonymous]
    [Area("OAuth")]
    [Route("OAuth/[controller]/[action]")]
    public class LoginController : Controller
    {
        public readonly Interface.IUserManager UserManager;
        public LoginController(Interface.IUserManager userManager)
        {
            UserManager = userManager;
        }

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



    }
}