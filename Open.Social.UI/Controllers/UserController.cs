using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Open.Social.UI.Controllers
{
    [Produces("application/json")]
    [Route("api/User/[action]")]
    public class UserController : Controller
    {
        private readonly Interface.IUserManager userManager;
        public UserController(Interface.IUserManager _userManager)
        {
            userManager = _userManager;
        }

        public IActionResult Autenticacao(Open.Social.Core.Model.User.User user)
        {
            return Ok(userManager.Authenticate(user));
        }
        public IActionResult Create(Open.Social.Core.Model.User.User user)
        {
            userManager.SaveOrUpdate(user);
            return Ok();
        }
        


        public Open.Social.Core.Model.User.User GetUser()
        {
            return null;
        }
    }
}