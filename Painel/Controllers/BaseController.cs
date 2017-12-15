using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Painel.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
       
    }
}