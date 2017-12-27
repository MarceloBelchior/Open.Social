using Open.Social.AzureDocumentDb.Interface;
using Open.Social.AzureDocumentDb.Interface.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Open.Social.AzureDocumentDb.Model
{
 public class PartnerEntity : CollectionItemEntity, IDocumentEntity<PartnerEntity>
    {
        public string name { get; set; }
        public string fantasy { get; set; }
        public string cnpj { get; set; }
        public string ie { get; set; }
        public DateTime created { get; set; }
        public bool active { get; set; }
        public bool block { get; set; }
        public byte[] logo { get; set; }
        public Guid address { get; set; }

        public PartnerEntity Init()
        {
            return Init(Guid.NewGuid()) as PartnerEntity;
        }

    }
}
