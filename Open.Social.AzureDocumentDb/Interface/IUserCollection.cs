using Open.Social.AzureDocumentDb.Interface.Helper;
using Open.Social.AzureDocumentDb.Model;

namespace Open.Social.AzureDocumentDb.Interface
{
    public interface IUserCollection : IDocumentCollection<UserEntity>
    {
        IUserCollection OrderByName();
        IUserCollection WhereByEmail(string email);
    }
}

