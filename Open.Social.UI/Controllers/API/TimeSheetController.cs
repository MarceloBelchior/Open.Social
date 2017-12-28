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
using Open.Social.Core.Model.TimeSheet;
using Open.Social.Core.Model.User;

namespace Open.Social.UI.Controllers.API
{
    [Produces("application/json")]
    [Route("api/Users/[action]")]
    public class TimeSheetController : BaseController
    {

        public readonly Interface.ITimeSheetManager _timeSheetManager;
        private readonly IConfiguration _configuration;

        public TimeSheetController(Interface.ITimeSheetManager timeSheetManager, IConfiguration configuration)
        {
            _timeSheetManager = timeSheetManager;
            _configuration = configuration;
        }




        [HttpPost]
        public async Task<object> AddOrUpdate([FromBody]TimeSheet timeSheet)
        {
            if (timeSheet.id == Guid.Empty)
                await _timeSheetManager.CreateAsync(timeSheet);
            else
                await _timeSheetManager.UpdateAsync(timeSheet);
            return Ok();
        }





        [HttpPost]
        public async Task<IEnumerable<Core.Model.TimeSheet.TimeSheet>> GetTimeSheet([FromBody]DateTime idateTime, DateTime dateTime, User user)
        {

            return null;

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