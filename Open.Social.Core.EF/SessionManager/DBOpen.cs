using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Open.Social.Core.EF.SessionManager
{
   public class DBOpen : DbContext
    {
        public DBOpen(DbContextOptions<DBOpen> options) : base(options)
        {
            
        }
  
        //public DbSet<OpenSquare.Model.TimeSheet.TimeSheet> TimeSheet { get; set; }

    }
}
