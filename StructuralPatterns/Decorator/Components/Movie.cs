using System;

namespace DesignPatternSamples.StructuralPatterns.Decorator.Components
{
    public class Movie : IComponent
    {
        public void Show()
            => Console.WriteLine($"{GetType().Name} - Exibição Padrão");

    }
}
