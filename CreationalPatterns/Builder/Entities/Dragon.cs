using DesignPatternSamples.CrossCutting.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatternSamples.CreationalPatterns.Builder.Entities
{
    public class Dragon
    {
        public Dragon(string name, EColor color, IList<Wing> wings, IList<Head> heads, int age, string tail, DateTime? evolutionData, bool master, string feet)
        {
            Dna = Guid.NewGuid();
            Name = name;
            Color = color;
            Wings = wings;
            Heads = heads;
            Age = age;
            Tail = tail;
            EvolutionData = evolutionData;
            Master = master;
            Feet = feet;
        }

        public Guid Dna { get; }
        public string Name { get; private set; }
        public EColor Color { get; private set; }
        public IList<Wing> Wings { get; private set; }
        public IList<Head> Heads { get; private set; }
        public int Age { get; private set; }
        public string Tail { get; private set; }
        public DateTime? EvolutionData { get; private set; }
        public bool Master { get; private set; }
        public string Feet { get; private set; }

        public override string ToString()
            => string.Join("\n", $"Dragão - Dna:{Dna}, Name:{Name}, Color:{Color}, Age:{Age}, Tail:{Tail}, EvolutionData:{EvolutionData}, Master:{Master}, Feet:{Feet}",
                string.Join("\n", Heads.Select(x => x.ToString())),
                string.Join("\n", Wings.Select(x => x.ToString()))
                );


    }
}
