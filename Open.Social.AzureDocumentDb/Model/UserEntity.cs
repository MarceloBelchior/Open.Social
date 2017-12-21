using Open.Social.AzureDocumentDb.Interface;
using System;

namespace Open.Social.AzureDocumentDb.Model
{
    public class UserEntity : CollectionItemEntity, IDocumentEntity<UserEntity>
    {
        public string name { get; set; }
        public string email { get; set; }
        public DateTime birth { get; set; }
        public byte[] photo { get; set; }
        public Guid salt { get; set; }
        public string password { get; set; }
        public DateTime created { get; set; }
        public DateTime update { get; set; }
        public DateTime expire { get; set; }

        public UserEntity Init()
        {
            return Init(Guid.NewGuid()) as UserEntity;
        }
    }
}
