using DesignPatternSamples.StructuralPatterns.Decorator.Components;

namespace DesignPatternSamples.StructuralPatterns.Decorator.Decorators
{
    public abstract class Decorator : IComponent
    {
        protected Decorator(IComponent component)
        {
            Component = component;
        }

        public IComponent Component { get; set; }

        public virtual void DoSomeThing()
            => Component.DoSomeThing();
    }
}
