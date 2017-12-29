using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Open.Social.UI.Controllers
{

    public class OpenController : BaseController
    {

        public IActionResult Index()
        {



            return View();
        }
        public IActionResult Body()
        {
            return View();
        }
    }
}