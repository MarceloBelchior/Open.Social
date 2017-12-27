using Open.Social.AzureDocumentDb.Interface;
using Open.Social.AzureDocumentDb.Interface.Helper;
using Open.Social.AzureDocumentDb.Model;
using System.Linq;

namespace Open.Social.AzureDocumentDb.Collection
{
    public class UserCollection : CollectionBase<UserEntity>, IUserCollection
    {
        public UserCollection(IAzureDocDatabase database, string collectionName) : base(database, collectionName)
        {
        }
        public IUserCollection OrderByName()
        {
            Query = Query.OrderBy(x => x.name);
            return this;
        }
        public IUserCollection WhereByEmail(string email)
        {
            Query = Query.Where(c => c.email == email);
            return this;

        }
    }
}
