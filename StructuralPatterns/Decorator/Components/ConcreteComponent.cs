using System;

namespace DesignPatternSamples.StructuralPatterns.Decorator.Components
{
    public class ConcreteComponent : IComponent
    {
        public void DoSomeThing()
        {
            Console.WriteLine("ConcreteComponent - Comportamento Padrão");
        }
    }
}
