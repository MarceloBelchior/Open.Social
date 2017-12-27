using System;
using System.Collections.Generic;
using System.Text;

namespace Open.Social.Core.Model.User
{
   public class Partner : EntidadeBase
    {
        public string name { get; set; }
        public string fantasy { get; set; }
        public string cnpj { get; set; }
        public string ie { get; set; }
        public DateTime created { get; set; }
        public bool active { get; set; }
        public bool block { get; set; }
        public byte[] logo { get; set; }
        
    }
}
