using Open.Social.Core.EF.SessionManager;
using Open.Social.Core.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Open.Social.Core.EF.Repository
{
    public class UserRepository : BaseRepository<Model.User.User>
    {
        public override User Insert(User item, bool saveImmediately = true)
        {
            item.salt = Guid.NewGuid();
            item.expire = DateTime.Now.AddDays(30);

            return base.Insert(item, saveImmediately);
        }
    }
}
