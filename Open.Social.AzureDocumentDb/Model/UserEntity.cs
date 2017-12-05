using Open.Social.AzureDocumentDb.Interface;
using System;

namespace Open.Social.AzureDocumentDb.Model
{
    public class UserEntity : CollectionItemEntity, IDocumentEntity<UserEntity>
    {
        public string email { get; set; }
        public string password { get; set; }
        public string salt { get; set; }
        public UserEntity Init()
        {
            return Init(Guid.NewGuid()) as UserEntity;
        }
    }
}
