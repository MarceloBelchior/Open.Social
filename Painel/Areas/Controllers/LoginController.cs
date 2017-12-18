using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Painel.Areas.Controllers
{
    
    [AllowAnonymous]
    [Area("OAuth")]
    [Route("/[controller]/[action]")]
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

        //[HttpPost]
        //[Route("Autenticacao")]
        public async Task Autenticacao(object entity)
        {
            //    await _timeSheetManager.CreateAsync(entity);
        }



    }
}