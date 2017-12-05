using Newtonsoft.Json;
using System;

namespace Open.Social.AzureDocumentDb.Model
{
    public class CollectionItemEntity
    {
        public CollectionItemEntity Init(Guid id)
        {
            Id = id;
            return this;
        }

        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
    }
}
