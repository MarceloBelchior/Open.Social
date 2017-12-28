
using Open.Social.Core.Interface;
using Open.Social.Core.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Open.Social.UI.Manager
{
    public class UserManager : Interface.IUserManager
    {
        private readonly IUserService userService;
        public UserManager(IUserService _userService)
        {
            userService = _userService;
        }

        public IEnumerable<User> Consult(Expression<Func<User, bool>> expression)
        {
            return this.userService.Consult(expression);
        }

        public void Remove(User entidade)
        {
            this.userService.Remove(entidade);
        }

        public void SaveOrUpdate(User entity)
        {
            this.userService.SaveOrUpdate(entity);
        }

        public User SelectById(User entidade)
        {
            return this.userService.SelectById(entidade);
        }
        public User Authenticate(User user)
        {
            if (userService.Autenticate(user))
            {
             User  entity =  this.userService.SelectByLogin(user);
                entity.salt = Guid.Empty;
                entity.password = null;
                return entity;

            }
            return null;
        }
    }
}
