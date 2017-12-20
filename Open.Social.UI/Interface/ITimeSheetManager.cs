using Open.Social.Core.Model.TimeSheet;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Open.Social.UI.Interface
{
    public interface ITimeSheetManager
    {

        IList<Open.Social.Core.Model.TimeSheet.TimeSheet> GetAll();
        TimeSheet GetById(Guid id);
        Task CreateAsync(Open.Social.Core.Model.TimeSheet.TimeSheet entity);
        Task UpdateAsync(Open.Social.Core.Model.TimeSheet.TimeSheet entity);
        Task DeleteAsync(Guid cartId);

    }
}
