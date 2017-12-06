using Open.Social.Core.Model.TimeSheet;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Open.Social.Core.Interface
{
   public interface ITimeSheetManagerStore
    {

        IList<Core.Model.TimeSheet.TimeSheet> GetAll();
        TimeSheet GetById(Guid id);
        Task CreateAsync(Core.Model.TimeSheet.TimeSheet entity);
        Task UpdateAsync(Core.Model.TimeSheet.TimeSheet entity);
        Task DeleteAsync(Guid cartId);

    }

    public interface ITimeSheetService
    {
        IList<Core.Model.TimeSheet.TimeSheet> GetAll();
        TimeSheet GetById(Guid id);
        Task CreateAsync(Core.Model.TimeSheet.TimeSheet entity);
        Task UpdateAsync(Core.Model.TimeSheet.TimeSheet entity);
        Task DeleteAsync(Guid cartId);

    }
}
