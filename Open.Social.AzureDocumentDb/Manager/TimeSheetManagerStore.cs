using AutoMapper;
using Open.Social.AzureDocumentDb.Interface;
using Open.Social.AzureDocumentDb.Model;
using Open.Social.Core.Interface;
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
            Mapper.Initialize(cfg => cfg.CreateMap<Core.Model.TimeSheet.TimeSheet, TimeSheetEntity>());
        }

        #region ICartStorage Methods

        public IList<Core.Model.TimeSheet.TimeSheet> GetAll()
        {
            var entities = _timeSheetCollection
                .SetupBaseQuery<ITimeSheetCollection>()
                .RunQuery();
            return Mapper.Map<IList<TimeSheetEntity>, IList<TimeSheet>>(entities);
        }

        public TimeSheet GetById(Guid id)
        {
            var entity = _timeSheetCollection
                .SetupBaseQuery<ITimeSheetCollection>()
                .GetById(id)
                .RunQuery()
                .FirstOrDefault();

            TimeSheet dto = Mapper.Map<TimeSheet>(entity);
            return dto;
        }


        public async Task CreateAsync(Core.Model.TimeSheet.TimeSheet entity)
        {
            TimeSheetEntity dto = Mapper.Map<TimeSheetEntity>(entity);

            await _timeSheetCollection.CreateAsync(dto);
        }

        public async Task UpdateAsync(Core.Model.TimeSheet.TimeSheet entity)
        {
            TimeSheetEntity dto = Mapper.Map<TimeSheetEntity>(entity);
            await _timeSheetCollection.UpdateAsync(entity,entity.id.ToString());
        }

        public async Task DeleteAsync(Guid cartId)
        {
            await _timeSheetCollection.DeleteAsync(cartId.ToString());
        }

        #endregion
        
    }
}
