using DesignPatternSamples.ConsoleAPP.Services;
using System;

namespace DesignPatternSamples.ConsoleAPP
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            //Creational Patterns
            CreationalService.RunFactoryMethodSample();
            CreationalService.RunAbstractFactorySample();
            CreationalService.RunBuilderSample();
            CreationalService.RunPrototypeSample();
            CreationalService.RunSingletonSample();

            //Structural Patterns
            StructuralService.RunAdapterSample();
            StructuralService.RunBrigdeSample();
            StructuralService.RunCompositeSample();
            StructuralService.RunDecoratorSample();
            StructuralService.RunFacadeSample();
            StructuralService.RunFlyweightSample();
            StructuralService.RunProxySample();

            //Behavioral Patterns
            BehavioralService.RunChainOfResponsibilitySample();
            BehavioralService.RunCommandSample();
            BehavioralService.RunInterpreterSample();
            BehavioralService.RunIteratorSample();
            BehavioralService.RunMediatorSample();
            BehavioralService.RunMementosSample();
            BehavioralService.RunObserverSample();

            Console.ReadKey();
        }
    }
}
