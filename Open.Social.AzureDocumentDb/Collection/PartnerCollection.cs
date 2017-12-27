using Open.Social.AzureDocumentDb.Interface;
using Open.Social.AzureDocumentDb.Interface.Helper;
using Open.Social.AzureDocumentDb.Model;

namespace Open.Social.AzureDocumentDb.Collection
{
    public class PartnerCollection : CollectionBase<PartnerEntity>, IPartnerCollection
    {
        public PartnerCollection(IAzureDocDatabase database, string collectionName) : base(database, collectionName)
        {
        }
    }
}

    