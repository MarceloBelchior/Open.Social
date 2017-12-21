using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Open.Social.Core.EF.Ioc
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => c.Resolve<Task<Repository.UserRepository>>().Result).As<Core.Interface.IUserManagerRepository>().SingleInstance();
        }
    }
}
