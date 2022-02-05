using DesignPatternSamples.StructuralPatterns.Decorator.Components;
using System;

namespace DesignPatternSamples.StructuralPatterns.Decorator.Decorators
{
    public class TrailerDecorator : Decorator
    {
        public TrailerDecorator(IComponent component) : base(component)
        {
        }
        public override void Show()
        {
            Console.WriteLine($"{GetType().Name} - Exibe o trailer antes da exibição do filme");
            base.Show();
        }
    }
}
