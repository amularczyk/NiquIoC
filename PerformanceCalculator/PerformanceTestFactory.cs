using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerformanceCalculator.Common;
using PerformanceCalculator.Containers.TestsAutofac;
using PerformanceCalculator.Containers.TestsDryIoc;
using PerformanceCalculator.Containers.TestsLightInject;
using PerformanceCalculator.Containers.TestsNiquIoC_Full;
using PerformanceCalculator.Containers.TestsNiquIoC_Partial;
using PerformanceCalculator.Containers.TestsSimpleInjector;
using PerformanceCalculator.Containers.TestsStructureMap;
using PerformanceCalculator.Containers.TestsUnity;
using PerformanceCalculator.Containers.TestsWindsor;
using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator
{
    internal static class PerformanceTestFactory
    {
        internal static IPerformanceTest GetPerformance(string name)
        {
            switch (name)
            {
                case ContainerName.Autofac:
                    return new AutofacPerformanceTest();

                case ContainerName.DryIoc:
                    return new DryIocPerformanceTest();

                case ContainerName.LightInject:
                    return new LightInjectPerformanceTest();

                case ContainerName.NiquIoC:
                    return new NiquIoCPartialPerformanceTest();

                case ContainerName.NiquIoCFull:
                    return new NiquIoCFullPerformanceTest();

                case ContainerName.SimpleInjector:
                    return new SimpleInjectorPerformanceTest();

                case ContainerName.StructureMap:
                    return new StructureMapPerformanceTest();

                case ContainerName.Unity:
                    return new UnityPerformanceTest();

                case ContainerName.Windsor:
                    return new WindsorPerformanceTest();

                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
