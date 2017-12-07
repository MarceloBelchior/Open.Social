using Open.Social.Core.Model.TimeSheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Open.Social.Interface
{
    public interface ITimeSheetManager
    {

        IList<Core.Model.TimeSheet.TimeSheet> GetAll();
        TimeSheet GetById(Guid id);
        Task CreateAsync(Core.Model.TimeSheet.TimeSheet entity);
        Task UpdateAsync(Core.Model.TimeSheet.TimeSheet entity);
        Task DeleteAsync(Guid cartId);

    }
}
