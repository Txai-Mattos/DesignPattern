using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternSamples.BehavioralPatterns.Mediator.Mediators
{
    public interface IMediator
    {
        void Notify(object sender, string @event);
    }
}
