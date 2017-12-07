using Autofac;

namespace Open.Social.IoC
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Manager.TimeSheetManager>().As<Interface.ITimeSheetManager>().SingleInstance();
        }
    }
}
