using Open.Social.AzureDocumentDb.Interface;
using Open.Social.AzureDocumentDb.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Open.Social.AzureDocumentDb
{

    public class CollectionBase<T> : AzureDocCollection<T>, IDocumentCollection<T> where T : CollectionItemEntity
    {
        public CollectionBase(IAzureDocDatabase database, string collectionName) : base(database, collectionName)
        {
        }
        public async Task InitializeAsync()
        {
            await ExecuteWithRetries();
        }
    }
}
