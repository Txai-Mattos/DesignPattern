using DesignPatternSamples.BehavioralPatterns.TemplateMethod.Abstracts;
using DesignPatternSamples.CrossCutting.Extensions;

namespace DesignPatternSamples.BehavioralPatterns.TemplateMethod.Concretes
{
    public class Concrete2 : AbstractClass
    {
        protected override void Step3()
        {
            this.Write($"{nameof(Step3)} into {nameof(Concrete2)}");
        }

        protected override void Hook()
        {
            this.Write($"{nameof(Hook)} into {nameof(Concrete2)}");
        }
    }
}
