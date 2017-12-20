
using Microsoft.AspNetCore.Mvc;
using Open.Social.Core.Model.User;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Open.Social.UI.Interface
{
    public interface IUserManager
    {
        void SaveOrUpdate(User entity);
        IEnumerable<User> Consult(Expression<Func<User, bool>> expression);
        void Remove(User entidade);
        User SelectById(User entidade);
        User Authenticate(User entidade);
    }
}
