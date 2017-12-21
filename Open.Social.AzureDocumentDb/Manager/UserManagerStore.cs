using Open.Social.AzureDocumentDb.Interface;
using Open.Social.AzureDocumentDb.Model;
using Open.Social.Core.Interface;
using Open.Social.Core.Model.TimeSheet;
using Open.Social.Core.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Open.Social.AzureDocumentDb.Manager
{
    public class UserManagerStore : IUserManagerStore
    {
        private readonly IUserCollection _userCollection;


        public UserManagerStore(IUserCollection  userCollection)
        {
            _userCollection = userCollection;
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
