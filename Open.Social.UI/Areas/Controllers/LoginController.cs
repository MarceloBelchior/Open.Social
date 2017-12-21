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

        [HttpPost]
        public IActionResult Autenticacao(string login, string password)
        {
            if (login == "teste@teste" && password == "trade4b")
            {
                var user = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, "bob") }, CookieAuthenticationDefaults.AuthenticationScheme));
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user);

                //var redirectUrl = Url.Action(nameof(OpenController.Index), "Open");
                return  Ok(true);
            }
            return Ok("Usuario ou senha invalidos");


            //var token = new JwtTokenBuilder()
            //        .AddSecurityKey(JwtSecurityKey.Create("fiver-secret-key"))
            //        .AddSubject("james bond")
            //        .AddIssuer("Fiver.Security.Bearer")
            //        .AddAudience("Fiver.Security.Bearer")
            //        .AddClaim("MembershipId", "111")
            //        .AddExpiry(1)
            //        .Build();

            ////return Ok(token);
            //return Ok(token.Value);
            //you can add all of ClaimTypes in this collection
            //var claims = new List<Claim>()
            //    {
            //        new Claim(ClaimTypes.Name,login),
            //        new Claim(ClaimTypes.Role,"Admin")
            //        //,new Claim(ClaimTypes.Email,"emailaccount@microsoft.com") 
            //    };

            ////init the identity instances
            //var userPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, "SuperSecureLogin"));

            ////signin
            //HttpContext.Authentication.SignInAsync("Cookie", userPrincipal, new Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
            //{
            //    IsPersistent = false,
            //    AllowRefresh = false,
            //    ExpiresUtc = DateTime.UtcNow.AddHours(1)
            //});



            //return RedirectPermanent("./");

            //UserManager.Authenticate(new Core.Model.User.User() { email = login, password = password }) ;
            //var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            //identity.AddClaim(new Claim(login, login));

            //HttpContext.SignInAsync(new CookieAuthenticationDefaults().AuthenticationSch new ClaimsPrincipal().AddIdentity(identity)));
            //{
            //    IsPersistent = true,
            //        ExpiresUtc = DateTime.UtcNow.AddMinutes(20)
            // });
            //user.UserName = login;

            //  return  RedirectPermanent("/#/");
            //    await _timeSheetManager.CreateAsync(entity);
        }



    }
}