using DesignPatternSamples.BehavioralPatterns.Iterator.Iterators;
using DesignPatternSamples.CrossCutting.Extensions;
using System.Collections.Generic;

namespace DesignPatternSamples.BehavioralPatterns.Iterator.Aggregates
{
    public class FruitAggregate : IAggregate
    {
        public FruitAggregate()
        {
            Fruits = new();
        }
        private List<string> Fruits { get; set; }

        public IIterator GetIterator()
        {
            this.WriteIntoConsole($"Criando interador e passando a lista ( {string.Join(",", Fruits)} ) com : {Fruits.Count} items \n");
            return new ImparIterator<string>(Fruits);
        }

        public void AddFruit(string fruit)
        {
            Fruits.Add(fruit);
        }
    }
}
