using Open.Social.Core.EF.SessionManager;
using Open.Social.Core.Model.TimeSheet;
using Open.Social.Core.Model.User;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace Open.Social.Core.EF.Repository
{
    public class UserRepository : BaseRepository<Model.User.User>, Core.Interface.IUserManagerRepository
    {
        public IEnumerable<User> Consult(Expression<Func<User, bool>> expression)
        {
            return base.Select(expression);
        }

        public override User Insert(User item, bool saveImmediately = true)
        {
            item.salt = Guid.NewGuid();
            item.expire = DateTime.Now.AddDays(30);

            return base.Insert(item, saveImmediately);
        }

        public void Remove(User entidade)
        {
            base.Delete(entidade);
        }

        public void SaveOrUpdate(User entity)
        {
            if (entity.id == 0)
                base.Insert(entity);
            else
                base.Update(entity);
        }

        public User SelectById(User entidade)
        {
            return base.SelectById(entidade.id);
        }
    }
}
