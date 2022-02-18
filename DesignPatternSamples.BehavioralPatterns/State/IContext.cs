using DesignPatternSamples.BehavioralPatterns.State.States;

namespace DesignPatternSamples.BehavioralPatterns.State
{
    //Interface que permite os estados interagirem com o contexto concreto
    public interface IContext
    {
        void ChangeState(IState state);
    }
}
