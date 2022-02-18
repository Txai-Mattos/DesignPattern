namespace DesignPatternSamples.BehavioralPatterns.State.States
{
    public interface IState
    {
        void WarmUp(IContext context);
        void Freeze(IContext context);
        bool CanDrink();
    }
}
