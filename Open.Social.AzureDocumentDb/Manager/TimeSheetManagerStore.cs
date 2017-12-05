using Open.Social.AzureDocumentDb.Interface;
using Open.Social.AzureDocumentDb.Model;
using Open.Social.Core.Model.TimeSheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open.Social.AzureDocumentDb.Manager
{
    public class TimeSheetManagerStore : ITimeSheetManagerStore
    {
        private readonly ITimeSheetCollection _timeSheetCollection;


        public TimeSheetManagerStore(ITimeSheetCollection timeSheetCollection)
        {
            _timeSheetCollection = timeSheetCollection;
        }

        #region ICartStorage Methods

        public IList<Core.Model.TimeSheet.TimeSheet> GetAll()
        {
            var entities = _timeSheetCollection
                .SetupBaseQuery<ITimeSheetCollection>()
                .RunQuery();

            //You should use Automapper for this
            return entities.Select(c => new Core.Model.TimeSheet.TimeSheet()
            {
                reg = c.Id,
                BreakFestEnd = c.BreakFestEnd,
                BreakFestIni = c.BreakFestIni,
                CliendId = c.CliendId,
                Comments = c.Comments,
                IniDay = c.IniDay,
                EndDay = c.EndDay,
                ExtendEnd = c.ExtendEnd,
                ExtendInit = c.ExtendInit
            }).ToList();
        }

        public TimeSheet GetById(Guid id)
        {
            var entity = _timeSheetCollection
                .SetupBaseQuery<ITimeSheetCollection>()
                .GetById(id)
                .RunQuery()
                .FirstOrDefault();

            return new Core.Model.TimeSheet.TimeSheet()
            {
                reg = entity.Id,
                BreakFestEnd = entity.BreakFestEnd,
                BreakFestIni = entity.BreakFestIni,
                CliendId = entity.CliendId,
                Comments = entity.Comments,
                IniDay = entity.IniDay,
                EndDay = entity.EndDay,
                ExtendEnd = entity.ExtendEnd,
                ExtendInit = entity.ExtendInit

            };
        }


        public async Task CreateAsync(Core.Model.TimeSheet.TimeSheet entity)
        {
            var timeSheet = new TimeSheetEntity
            {
               Id = entity.reg,
                BreakFestEnd = entity.BreakFestEnd,
                BreakFestIni = entity.BreakFestIni,
                CliendId = entity.CliendId,
                Comments = entity.Comments,
                IniDay = entity.IniDay,
                EndDay = entity.EndDay,
                ExtendEnd = entity.ExtendEnd,
                ExtendInit = entity.ExtendInit
            };

            await _timeSheetCollection.CreateAsync(entity.Init());
        }

        public async Task UpdateAsync(Core.Model.TimeSheet.TimeSheet entity)
        {
            await _timeSheetCollection.UpdateAsync(entity, entity.reg.ToString());
        }

        public async Task DeleteAsync(Guid cartId)
        {
            await _timeSheetCollection.DeleteAsync(cartId.ToString());
        }

        #endregion
        
    }
}
