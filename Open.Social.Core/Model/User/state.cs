using System;
using System.Collections.Generic;
using System.Text;

namespace Open.Social.Core.Model.User
{
  public class state : EntidadeBase
    {
        public string name { get; set; }
        public string sigla { get; set; }
        public Country country { get; set; }
    }
}
