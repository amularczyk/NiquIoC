﻿using NiquIoC;

namespace PerformanceCalculator.Containers.TestsNiquIoC_Full
{
    public class PerThreadNiquIoCFullRegistration : Registration
    {
        public override void Register<TFrom, TTo>(object container)
        {
            var c = (Container)container;

            c.RegisterType<TFrom, TTo>().AsPerThread();
        }
    }
}