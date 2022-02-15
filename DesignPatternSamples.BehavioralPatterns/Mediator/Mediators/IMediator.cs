namespace DesignPatternSamples.BehavioralPatterns.Mediator.Mediators
{
    public interface IMediator
    {
        void Notify(object sender, string @event);
    }
}
