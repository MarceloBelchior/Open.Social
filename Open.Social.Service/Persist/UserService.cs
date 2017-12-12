using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Open.Social.Core.Model.User;

namespace Open.Social.Service.Persist
{
    public class UserService : Core.Interface.IUserService
    {
        private readonly Core.Interface.IUserManagerStore _userManagerStore;
        public UserService(Core.Interface.IUserManagerStore userManagerStore)
        {
            _userManagerStore = userManagerStore;
        }
        public IEnumerable<User> Consult(Expression<Func<User, bool>> expression)
        {
            return _userManagerStore.Consult(expression);

        }

        public void Remove(User entidade)
        {
            _userManagerStore.Remove(entidade);
        }

        public void SaveOrUpdate(User entity)
        {
            _userManagerStore.SaveOrUpdate(entity);
        }

        public User SelectById(User entidade)
        {
            return _userManagerStore.SelectById(entidade);
        }
    }
}
