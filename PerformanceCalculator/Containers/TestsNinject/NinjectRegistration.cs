﻿using Ninject;

namespace PerformanceCalculator.Containers.TestsNinject
{
    public class NinjectRegistration : Registration
    {
        public override void RegisterSingleton<TFrom, TTo>(object container)
        {
            var c = (StandardKernel)container;

            c.Bind<TFrom>().To<TTo>().InSingletonScope();
        }

        public override void RegisterTransient<TFrom, TTo>(object container)
        {
            var c = (StandardKernel)container;

            c.Bind<TFrom>().To<TTo>().InTransientScope();
        }

        public override void RegisterPerThread<TFrom, TTo>(object container)
        {
            var c = (StandardKernel)container;

            c.Bind<TFrom>().To<TTo>().InThreadScope();
        }
    }
}