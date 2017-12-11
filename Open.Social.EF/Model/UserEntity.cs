using System;
using System.Collections.Generic;
using System.Text;

namespace Open.Social.EF.Model
{
  public class UserEntity
    {
        public int Id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string salt { get; set; }
    }
}
