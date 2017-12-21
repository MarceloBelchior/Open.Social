using Open.Social.Core.Model.TimeSheet;
using Open.Social.Core.Model.User;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Open.Social.Service.NoSQL
{
  public class UserService : Core.Interface.IUserService
    {
        private readonly Core.Interface.IUserManagerStore _userManager;
        public UserService(Core.Interface.IUserManagerStore userManager)
        {
            _userManager = userManager;

        }

        public bool Autenticate(User entidade)
        {
             Utils.Authenticate.Authenticate.LogOn(entidade, 3600);
            return true;
        }

        public IEnumerable<User> Consult(Expression<Func<User, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Remove(User entidade)
        {
            throw new NotImplementedException();
        }

        public void SaveOrUpdate(User entity)
        {
            throw new NotImplementedException();
        }

        public User SelectById(User entidade)
        {
            throw new NotImplementedException();
        }
    }
}
