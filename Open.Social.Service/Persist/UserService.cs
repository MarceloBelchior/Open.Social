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
        //private readonly Core.Interface.IUserManagerStore _userManagerStore;
        public UserService(Core.Interface.IUserManagerStore userManagerStore)
        {
        //    _userManagerStore = userManagerStore;
        }
        public IEnumerable<User> Consult(Expression<Func<User, bool>> expression)
        {
            //  return _userManagerStore.Consult(expression);
            return null;

        }

        public void Remove(User entidade)
        {
           // return null;
            //_userManagerStore.Remove(entidade);
        }

        public void SaveOrUpdate(User entity)
        {
            //return null;
            //_userManagerStore.SaveOrUpdate(entity);
        }

        public User SelectById(User entidade)
        {
            return null;// return _userManagerStore.SelectById(entidade);
        }

        public Boolean Autenticate(User entidade)
        {
            return Utils.Authenticate.Authenticate.LogOn(entidade, 3600);
            //Expression<Func<User, bool>> _where = c => c.email == entidade.email;
            //var i = _userManagerStore.Consult(_where);
            //if (i.Count() == 0)
            //      new NotImplementedException("Usuario ou senha invalidos.");
            //var _result = new Utils.Cryptografia.Cryptography().CypherValueByProjectConfiguration(entidade.password, i.FirstOrDefault().salt.ToString());
            //if (_result == i.FirstOrDefault().password)
            //    return Utils.Authenticate.Authenticate.LogOn(i.FirstOrDefault(), 3600);
            //return false;
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
