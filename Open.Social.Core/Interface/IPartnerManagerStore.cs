using Open.Social.Core.Model.User;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Open.Social.Core.Interface
{
  public  interface IPartnerManagerStore
    {
        void SaveOrUpdate(Partner entity);
        IEnumerable<Partner> Consult(Expression<Func<Partner, bool>> expression);
        void Remove(Partner entidade);
        Partner SelectById(Partner entidade);
    }


    public interface IPartnerService
    {
        void SaveOrUpdate(Partner entity);
        IEnumerable<Partner> Consult(Expression<Func<Partner, bool>> expression);
        void Remove(Partner entidade);
        Partner SelectById(Partner entidade);
        Boolean Autenticate(Partner entidade);
    }
}
