using DesignPatternSamples.CrossCutting.Extensions;

namespace DesignPatternSamples.StructuralPatterns.Decorator.Components
{
    public class Movie : IComponent
    {
        public void Show()
            => this.Write("Exibição Padrão");
    }
}
