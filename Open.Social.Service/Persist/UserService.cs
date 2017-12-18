using System;
using System.Collections.Generic;
using System.Linq;
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

        public User Autenticate(User entidade)
        {
            Expression<Func<User, bool>> _where = c => c.email == entidade.email;
            var i = _userManagerStore.Consult(_where).AsQueryable();
            if (i.Count() == 0)
                  new NotImplementedException("Usuario ou senha invalidos.");
            var _result = new Utils.Cryptografia.Cryptography().CypherValueByProjectConfiguration(entidade.password, i.FirstOrDefault().salt.ToString());
            if (_result == i.FirstOrDefault().password)
                return this.Clean(i);
            return null;
        }

        private User Clean(User entidade)
        {
            User i = new User();
            i = entidade;
            i.salt = Guid.Empty;
            i.password = string.Empty;
            return i;
        }
    }
}
