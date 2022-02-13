using DesignPatternSamples.BehavioralPatterns.Iterator.Iterators;

namespace DesignPatternSamples.BehavioralPatterns.Iterator.Aggregates
{
    public interface IAggregate
    {
        IIterator GetIterator();
    }
}
