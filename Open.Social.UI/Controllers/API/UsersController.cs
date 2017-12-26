using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Open.Social.UI.Controllers.API
{
    [Produces("application/json")]
    [Route("api/Users/[action]")]
    public class UsersController : Controller
    {
        public readonly Interface.IUserManager _userManager;
        public UsersController(Interface.IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Autenticacao(string login, string password)
        {
            if (login == "teste@teste" && password == "trade4b")
            {
                var user = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, "bob") }, CookieAuthenticationDefaults.AuthenticationScheme));
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user);
                return Ok(true);
            }
            return Ok("Usuario ou senha invalidos");           
        }

        [HttpPost]
        public IActionResult Logoff()
        {
            HttpContext.SignOutAsync();
            return Ok(true);
        }





        [HttpGet]
        public IEnumerable<Core.Model.User.User> GetUsers()
        {

            return this._userManager.Consult(null);
        }
        [HttpPost]
        public Core.Model.User.User Create([FromBody] Core.Model.User.User user)
        {
            user = new Core.Model.User.User() {
                birth = DateTime.Now, created = DateTime.Now,
                email = "marcelo.belchior@gmail.com", expire = DateTime.Now.AddYears(3),
                password = "123", name = "marcelo", salt = Guid.NewGuid(), update = DateTime.Now };
            _userManager.SaveOrUpdate(user);
            return user;
        }
       
    }
}