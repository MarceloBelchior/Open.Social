using Open.Social.Core.Model.User;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Open.Social.Core.Interface
{
  public  interface IUserManagerStore
    {
        void SaveOrUpdate(User user);
        IEnumerable<User> Consult(Expression<Func<User, bool>> expression);
        void Remove(User user);
        User SelectById(User user);
        User SelectByLogin(User user);
    }


    public interface IUserService
    {
        void SaveOrUpdate(User entity);
        IEnumerable<User> Consult(Expression<Func<User, bool>> expression);
        void Remove(User entidade);
        User SelectById(User entidade);
        Boolean Autenticate(User entidade);
        User SelectByLogin(User user);
    }
}
