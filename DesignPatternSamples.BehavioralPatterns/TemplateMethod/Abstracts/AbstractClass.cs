using DesignPatternSamples.CrossCutting.Extensions;

namespace DesignPatternSamples.BehavioralPatterns.TemplateMethod.Abstracts
{
    public abstract class AbstractClass
    {
        public void TemplateMethod()
        {
            Step1();
            Step2();
            Step3();
            Hook();
        }

        protected virtual void Hook()
        {
            this.Write($"{nameof(Hook)} into {nameof(AbstractClass)}");
        }

        protected abstract void Step3();

        private void Step2()
        {
            this.Write($"{nameof(Step2)} into {nameof(AbstractClass)}");
        }

        private void Step1()
        {
            this.Write($"{nameof(Step1)} into {nameof(AbstractClass)}");
        }
    }
}
