using DesignPatternSamples.BehavioralPatterns.Memento.Mementos;
using DesignPatternSamples.CrossCutting.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatternSamples.BehavioralPatterns.Memento.Caretakers
{
    //Caretaker - Gerencia os mementos
    public class MementoManager
    {
        public MementoManager()
        {
            Mementos = new();
        }
        private List<IMemento> Mementos { get; }


        public void SetMemento(IMemento memento)
        {
            this.Write($"Guardando o memento que foi criado na data {memento.GetDate():f}");
            Mementos.Add(memento);
        }
        public IMemento GetLast()
        {
            if (Mementos.Count == 0)
                return default;

            var memento = Mementos.Last();
            this.Write($"Retornando o memento armazenado, que fora criado na data {memento.GetDate():f}");
            return memento;
        }
    }
}
