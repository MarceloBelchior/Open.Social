using System;
using System.Collections.Generic;
using System.Text;

namespace Open.Social.Core.Model.User
{
    public class User : EntidadeBase
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

    }
}
