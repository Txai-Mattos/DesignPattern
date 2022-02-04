using DesignPatternSamples.StructuralPatterns.Decorator.Components;
using System;

namespace DesignPatternSamples.StructuralPatterns.Decorator.Decorators
{
    public class BeforeDecorator : Decorator
    {
        public BeforeDecorator(IComponent component) : base(component)
        {
        }
        public override void DoSomeThing()
        {
            Console.WriteLine($"{nameof(BeforeDecorator)} - Faz Algo Antes de executar o component");
            base.DoSomeThing();
        }
    }
}
