using System;
using System.Collections.Generic;
using System.Text;

namespace Open.Social.Core.Model.User
{
   public class Action : EntidadeBase
    {
        public string path { get; set; }
        public bool active { get; set;  }
        public string describe { get; set; }
        
    }
}
