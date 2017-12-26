﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Open.Social.Core.Model.User;

namespace Open.Social.UI.Controllers.API
{
    [Produces("application/json")]
    [Route("api/Admin/[action]")]
    public class AdminController : Controller
    {
        private readonly Interface.IUserManager _userManager;
        public AdminController(Interface.IUserManager userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            Expression<Func<User, bool>> where = m => m.id != Guid.Empty;
            return _userManager.Consult(where);
        }
        [HttpPost]
        public User CreateOrUpdateUser([FromBody]User user)
        {
            _userManager.SaveOrUpdate(user);
            return user;
        }
        [HttpPost]
        public void DeleteUSer(User user)
        {
            _userManager.Remove(user);
        }


    }
}