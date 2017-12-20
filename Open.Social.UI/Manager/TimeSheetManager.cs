using Open.Social.Core.Interface;
using Open.Social.Core.Model.TimeSheet;
using Open.Social.UI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Open.Social.UI.Manager
{
    public class TimeSheetManager : ITimeSheetManager
    {
        private readonly ITimeSheetService _timeSheetService;

        public TimeSheetManager(ITimeSheetService timeSheetService)
        {
            _timeSheetService = timeSheetService;
        }
        public IList<TimeSheet> GetAll()
        {
            return _timeSheetService.GetAll();
        }
        public TimeSheet GetById(Guid id)
        {
            return _timeSheetService.GetById(id);
        }
        public async Task CreateAsync(TimeSheet entity)
        {
            await _timeSheetService.CreateAsync(entity);
        }

        public Task UpdateAsync(TimeSheet entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid cartId)
        {
            throw new NotImplementedException();
        }

     


    }
}
