using DesignPatternSamples.CrossCutting.Extensions;
using DesignPatternSamples.StructuralPatterns.Decorator.Components;

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
            this.Write("Exibe a cena pós-crédito após a exibição do filme");
        }
    }
}
