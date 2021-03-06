﻿using Open.Social.AzureDocumentDb.Interface;
using Open.Social.AzureDocumentDb.Interface.Helper;
using Open.Social.AzureDocumentDb.Model;

namespace Open.Social.AzureDocumentDb.Collection
{
    public class TimeSheetCollection : CollectionBase<TimeSheetEntity>, ITimeSheetCollection
    {
        public TimeSheetCollection(IAzureDocDatabase database, string collectionName) : base(database, collectionName)
        {
        }
    }
}

    