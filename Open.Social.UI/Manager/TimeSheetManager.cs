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
        public async Task SaveOrUpdate(TimeSheet entity, Core.Model.User.User user)
        {
            entity.UserId = user.id;
            if (entity.id == Guid.Empty)
                await _timeSheetService.CreateAsync(entity);
            else
                await _timeSheetService.UpdateAsync(entity);
        }
        

        public Task DeleteAsync(Guid cartId)
        {
            throw new NotImplementedException();
        }

     


    }
}
