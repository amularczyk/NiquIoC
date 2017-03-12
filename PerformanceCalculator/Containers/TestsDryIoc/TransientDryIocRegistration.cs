﻿using DryIoc;

namespace PerformanceCalculator.Containers.TestsDryIoc
{
    public class TransientDryIocRegistration : Registration
    {
        public override void Register<TFrom, TTo>(object container)
        {
            var c = (Container)container;

            c.Register<TFrom, TTo>();
        }
    }
}