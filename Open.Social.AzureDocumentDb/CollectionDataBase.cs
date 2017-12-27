using Open.Social.AzureDocumentDb.Interface.Helper;
using Open.Social.AzureDocumentDb.Model;
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
