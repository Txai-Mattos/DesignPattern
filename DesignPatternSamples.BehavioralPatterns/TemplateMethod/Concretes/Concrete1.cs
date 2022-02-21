using DesignPatternSamples.BehavioralPatterns.TemplateMethod.Abstracts;
using DesignPatternSamples.CrossCutting.Extensions;

namespace DesignPatternSamples.BehavioralPatterns.TemplateMethod.Concretes
{
    public class Concrete1 : AbstractClass
    {
        protected override void Step3()
        {
            this.Write($"{nameof(Step3)} into {nameof(Concrete1)}");
        }
    }
}
