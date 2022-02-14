using DesignPatternSamples.BehavioralPatterns.Mediator.Colleagues;
using System;

namespace DesignPatternSamples.BehavioralPatterns.Mediator.Mediators
{
    public class ConcreteMediator : IMediator
    {
        public ConcreteMediator(Colleague1 colleague1, Colleague2 colleague2, Colleague3 colleague3)
        {
            Colleague1 = colleague1;
            Colleague1.SetMediator(this);
            Colleague2 = colleague2;
            Colleague2.SetMediator(this);
            Colleague3 = colleague3;
            Colleague3.SetMediator(this);
        }

        private readonly Colleague1 Colleague1; 
        private readonly Colleague2 Colleague2;
        private readonly Colleague3 Colleague3; 

        public void Notify(object sender, string @event)
        {
            var type = sender.GetType();

            if (type == Colleague1.GetType())
            {
                Colleague2.ReactToSomething(@event);
            }
            else if (type == Colleague2.GetType())
            {
                Colleague1.ReactToSomething(@event);
                Colleague3.ReactToSomething(@event);
            }
            else
            {
                Colleague2.ReactToSomething(@event);
            }
        }
    }
}

