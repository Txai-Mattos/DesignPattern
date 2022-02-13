namespace DesignPatternSamples.BehavioralPatterns.Iterator.Iterators
{
    public interface IIterator
    {
        object First();
        object Next();
        bool IsDone();
        object CurrentItem { get; }
    }
}
