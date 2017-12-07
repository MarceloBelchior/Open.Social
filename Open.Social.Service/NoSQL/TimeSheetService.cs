using Open.Social.Core.Model.TimeSheet;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Open.Social.Service.NoSQL
{
  public class TimeSheetService : Core.Interface.ITimeSheetService
    {
        private readonly Core.Interface.ITimeSheetManagerStore _timeSheetManagerStore;
        public TimeSheetService(Core.Interface.ITimeSheetManagerStore timeSheetManagerStore)
        {
            _timeSheetManagerStore = timeSheetManagerStore;

        }
        public IList<Core.Model.TimeSheet.TimeSheet> GetAll()
        {
            return _timeSheetManagerStore.GetAll();
        }
        public TimeSheet GetById(Guid id)
        {
            return _timeSheetManagerStore.GetById(id);
        }
        public Task CreateAsync(Core.Model.TimeSheet.TimeSheet entity)
        {
            return _timeSheetManagerStore.CreateAsync(entity);
        }
        public Task UpdateAsync(Core.Model.TimeSheet.TimeSheet entity)
        {
            return _timeSheetManagerStore.UpdateAsync(entity);
        }

        public Task DeleteAsync(Guid cartId)
        {
            return _timeSheetManagerStore.DeleteAsync(cartId);
        }
    }
}
