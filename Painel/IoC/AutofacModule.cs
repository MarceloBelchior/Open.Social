﻿using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Painel.IoC
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Manager.TimeSheetManager>().As<Interface.ITimeSheetManager>().SingleInstance();
        }
    }
}