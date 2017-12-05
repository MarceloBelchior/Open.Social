using Open.Social.AzureDocumentDb.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Open.Social.AzureDocumentDb.Collection
{
    public class TimeSheetCollection :   CollectionBase<TimeSheetEntity>, ITimeSheetCollection
    {
        public TimeSheetCollection(IAzureDocDatabase database, string collectionName) : base(database, collectionName)
        {
        }
    }
}

    {
    }
}
