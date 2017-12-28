using Open.Social.AzureDocumentDb.Interface;
using Open.Social.AzureDocumentDb.Interface.Helper;
using System;

namespace Open.Social.AzureDocumentDb.Model
{
    public class TimeSheetEntity:  CollectionItemEntity, IDocumentEntity<TimeSheetEntity>
    {
        public DateTime IniDay { get; set; }
        public DateTime EndDay { get; set; }
        public DateTime BreakFestIni { get; set; }
        public DateTime BreakFestEnd { get; set; }
        public DateTime ExtendInit { get; set; }
        public DateTime ExtendEnd { get; set; }
        public long CliendId { get; set; }
        public Guid UserId { get; set; }
        public long ProjectId { get; set; }
        public string Comments { get; set; }
        public TimeSheetEntity Init()
        {
            return Init(Guid.NewGuid()) as TimeSheetEntity;
        }

        

    }
}
