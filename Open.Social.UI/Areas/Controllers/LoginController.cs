using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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
        public IActionResult Login()
        {

            return View();
        }
     




    }
}