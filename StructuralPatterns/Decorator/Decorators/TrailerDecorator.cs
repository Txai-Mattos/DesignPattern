using DesignPatternSamples.CrossCutting.Extensions;
using DesignPatternSamples.StructuralPatterns.Decorator.Components;

namespace DesignPatternSamples.StructuralPatterns.Decorator.Decorators
{
    public class TrailerDecorator : Decorator
    {
        public TrailerDecorator(IComponent component) : base(component)
        {
        }
        public override void Show()
        {
            this.Write("Exibe o trailer antes da exibição do filme");
            base.Show();
        }
    }
}
