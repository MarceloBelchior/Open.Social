using Open.Social.AzureDocumentDb.Interface;
using Open.Social.AzureDocumentDb.Model;

namespace Open.Social.AzureDocumentDb.Collection
{
    public class UserCollection : CollectionBase<UserEntity>, IUserCollection
    {
        public UserCollection(IAzureDocDatabase database, string collectionName) : base(database, collectionName)
        {
        }
    }
}
