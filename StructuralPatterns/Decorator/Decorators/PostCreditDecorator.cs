using DesignPatternSamples.StructuralPatterns.Decorator.Components;
using System;

namespace DesignPatternSamples.StructuralPatterns.Decorator.Decorators
{
    public class PostCreditDecorator : Decorator
    {
        public PostCreditDecorator(IComponent component) : base(component)
        {
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"{GetType().Name} - Exibe a cena pós-crédito após a exibição do filme");
        }
    }
}
