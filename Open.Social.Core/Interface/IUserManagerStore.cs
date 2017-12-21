using Open.Social.Core.Model.User;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Open.Social.Core.Interface
{
  public  interface IUserManagerStore
    {
        void SaveOrUpdate(User entity);
        IEnumerable<User> Consult(Expression<Func<User, bool>> expression);
        void Remove(User entidade);
        User SelectById(User entidade);
    }

    public interface IUserService
    {
        void SaveOrUpdate(User entity);
        IEnumerable<User> Consult(Expression<Func<User, bool>> expression);
        void Remove(User entidade);
        User SelectById(User entidade);
        Boolean Autenticate(User entidade);
    }
}
