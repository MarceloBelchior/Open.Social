using System;
using System.Collections.Generic;
using System.Text;

namespace Open.Social.Core.Model.TimeSheet
{
    public class TimeSheet : EntidadeBase
    {
        public DateTime IniDay { get; set; }
        public DateTime EndDay { get; set; }
        public DateTime BreakFestIni { get; set; }
        public DateTime BreakFestEnd { get; set; }
        public DateTime ExtendInit { get; set; }
        public DateTime ExtendEnd { get; set; }
        public long CliendId { get; set; }
        public Guid UserId { get; set; }
        public long ProjectId { get; set; }
        public string Comments { get; set; }
        

     
    }
}

