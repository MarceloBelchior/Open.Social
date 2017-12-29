using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Open.Social.UI.Controllers.API
{

    [Authorize("Bearer"), Produces("application/json")]
    public class BaseAPIController : Controller
    {
    }
}