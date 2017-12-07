using Autofac;

namespace Open.Social.Service.IoC
{
   public class AutofacModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            //Using AutoActivate to populate our products since IStartable order is arbitrary
//            builder.RegisterType<ProductPopulateService>().AsSelf().AutoActivate();
            builder.RegisterType<NoSQL.TimeSheetService>().As<Core.Interface.ITimeSheetService>().SingleInstance();
        }


    }
}

