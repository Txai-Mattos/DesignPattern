using DesignPatternSamples.BehavioralPatterns.Mediator.Mediators;
using DesignPatternSamples.CrossCutting.Extensions;

namespace DesignPatternSamples.BehavioralPatterns.Mediator.Colleagues
{
    public class Colleague3
    {
        private IMediator Mediator { get; set; }

        public void SetMediator(IMediator mediator) => Mediator = mediator;

        public void DoSomeThing()
        {
            this.Write($"Executando o metodo {nameof(DoSomeThing)} e avisando ao {Mediator.GetType().Name}");
            Mediator.Notify(this, $"Disparado por: {this.GetType().Name}.{nameof(DoSomeThing)}");
        }

        internal void ReactToSomething(string @event)
        {
            this.Write($"{nameof(ReactToSomething)} - O mediator chamou esse metodo devido ao evento: {@event}");
        }
    }
}
