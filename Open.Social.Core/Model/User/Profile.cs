using System;
using System.Collections.Generic;
using System.Text;

namespace Open.Social.Core.Model.User
{
  public class Profile : EntidadeBase
    {
        public string name { get; set; }
        public DateTime created { get; set; }
       
    }
}
