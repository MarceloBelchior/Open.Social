using Open.Social.Core.Model.User;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Open.Social.Core.Interface
{
  public  interface IUserManagerStore
    {
        void SaveOrUpdate(Model.TimeSheet.TimeSheet timesheet);
        ICollection<Model.TimeSheet.TimeSheet> Consult(Expression<Func<Model.TimeSheet.TimeSheet, bool>> expression);
        void Remove(int timesheetId);
        Model.TimeSheet.TimeSheet SelectById(int TimeSheetId);
    }
}
