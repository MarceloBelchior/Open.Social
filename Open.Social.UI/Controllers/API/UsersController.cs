using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Open.Social.UI.Controllers.API
{
    [Produces("application/json")]
    [Route("api/Users/[action]")]
    public class UsersController : BaseController
    {

        public readonly Interface.IUserManager _userManager;
        private readonly IConfiguration _configuration;

        public UsersController(Interface.IUserManager userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost, AllowAnonymous]
        public async Task<object> Autenticacao(string login, string password)
        {
            if (login == "teste@teste" && password == "trade4b")
            {
                // return Ok(new { token = await GenerateJwtToken(login, new IdentityUser() { Email = login, UserName = login }) });
                return Ok(new { token = BuildToken() });
            }
            return BadRequest("Usuario ou senha invalidos");
        }


        private string BuildToken()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["JwtIssuer"],
              _configuration["JwtIssuer"],
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);

            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserModel Authenticate(LoginModel login)
        {
            UserModel user = null;

            if (login.Username == "mario" && login.Password == "secret")
            {
                user = new UserModel { Name = "Mario Rossi", Email = "mario.rossi@domain.com" };
            }
            return user;
        }

        public class LoginModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        private class UserModel
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public DateTime Birthdate { get; set; }
        }

        private async Task<object> GenerateJwtToken(string email, IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );
            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            //  return new JwtSecurityTokenHandler().WriteToken(token);
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
            user = new Core.Model.User.User()
            {
                birth = DateTime.Now,
                created = DateTime.Now,
                email = "marcelo.belchior@gmail.com",
                expire = DateTime.Now.AddYears(3),
                password = "123",
                name = "marcelo",
                salt = Guid.NewGuid(),
                update = DateTime.Now
            };
            _userManager.SaveOrUpdate(user);
            return user;
        }

    }


}