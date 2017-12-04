using System;
using System.Collections.Generic;
using System.Text;

namespace Open.Social.Core.Model.User
{
   public class Access : EntidadeBase
    {
        public string path { get; set; }
        public Boolean status { get; set; }
        public User user { get; set; }

    }
}
