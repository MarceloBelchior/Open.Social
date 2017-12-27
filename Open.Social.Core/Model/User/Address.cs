using System;
using System.Collections.Generic;
using System.Text;

namespace Open.Social.Core.Model.User
{
   public class Address
    {
        public string address { get; set; }
        public string complement { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string zip { get; set; }
        public bool biling { get; set; }
        public bool active { get; set; }
        public bool todelivery { get; set; }
        public string comment { get; set; }
        public DateTime created { get; set; }
        public Guid userid { get; set; }

    }
}
