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

        public bool Autenticate(User user)
        {

            var entity = _userManager.SelectByLogin(user);
            if (entity == null)
                return false;
            string password = new Utils.Cryptografia.Cryptography().CypherValueByProjectConfiguration(user.password, entity.salt.ToString());
            if (entity.password == password)
                return true;
            return false;
        }
        

        public IEnumerable<User> Consult(Expression<Func<User, bool>> expression)
        {
           return  _userManager.Consult(expression);
        }

        public void Remove(User user)
        {
            _userManager.Remove(user);
        }

        public void SaveOrUpdate(User entity)
        {

            entity.salt = Guid.NewGuid();
            entity.id = Guid.NewGuid();
            entity.password = new Utils.Cryptografia.Cryptography().CypherValueByProjectConfiguration(entity.password, entity.salt.ToString());

            _userManager.SaveOrUpdate(entity);
        }

        public User SelectById(User user)
        {
            return _userManager.SelectById(user);
        }
        public User SelectByLogin(User user)
        {
            return _userManager.SelectByLogin(user);
        }
    }
}
