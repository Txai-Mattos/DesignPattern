using DesignPatternSamples.ConsoleAPP.Services;
using DesignPatternSamples.CrossCutting;
using System;

namespace DesignPatternSamples.ConsoleAPP
{
    public static class Program
    {
        public static void Main()
        {
            //Creational Patterns
            Execute.Run(CreationalService.RunFactoryMethodSample);
            Execute.Run(CreationalService.RunAbstractFactorySample);
            Execute.Run(CreationalService.RunBuilderSample);
            Execute.Run(CreationalService.RunPrototypeSample);
            Execute.Run(CreationalService.RunSingletonSample);

            //Structural Patterns
            Execute.Run(StructuralService.RunAdapterSample);
            Execute.Run(StructuralService.RunBrigdeSample);
            Execute.Run(StructuralService.RunCompositeSample);
            Execute.Run(StructuralService.RunDecoratorSample);
            Execute.Run(StructuralService.RunFacadeSample);
            Execute.Run(StructuralService.RunFlyweightSample);
            Execute.Run(StructuralService.RunProxySample);

            //Behavioral Patterns
            Execute.Run(BehavioralService.RunChainOfResponsibilitySample);
            Execute.Run(BehavioralService.RunCommandSample);
            Execute.Run(BehavioralService.RunInterpreterSample);
            Execute.Run(BehavioralService.RunIteratorSample);
            Execute.Run(BehavioralService.RunMediatorSample);
            Execute.Run(BehavioralService.RunMementosSample);
            Execute.Run(BehavioralService.RunObserverSample);
            Execute.Run(BehavioralService.RunStateSample);
            Execute.Run(BehavioralService.RunStrategySample);

            Console.ReadKey();
        }
    }
}
