using DesignPatternSamples.BehavioralPatterns.Observer.Observers;

namespace DesignPatternSamples.BehavioralPatterns.Observer.Subjects
{
    public interface ISubject
    {
        void AddObserver(IObserver observer);
        void RemoveObserver(IObserver observer);

        void Notify();
    }
}
