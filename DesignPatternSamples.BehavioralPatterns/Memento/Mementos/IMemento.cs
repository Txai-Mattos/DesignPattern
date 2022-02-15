using System;

namespace DesignPatternSamples.BehavioralPatterns.Memento.Mementos
{
    //Memento - interface simplificada
    public interface IMemento
    {
        DateTime GetDate();
        Guid GetGuid();
    }
}
