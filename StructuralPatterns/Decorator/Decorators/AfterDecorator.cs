using DesignPatternSamples.StructuralPatterns.Decorator.Components;
using System;

namespace DesignPatternSamples.StructuralPatterns.Decorator.Decorators
{
    public class AfterDecorator : Decorator
    {
        public AfterDecorator(IComponent component) : base(component)
        {
        }

        public override void DoSomeThing()
        {
            base.DoSomeThing();
            Console.WriteLine($"{nameof(AfterDecorator)} - Faz Algo Depois de executar o component");
        }
    }
}
