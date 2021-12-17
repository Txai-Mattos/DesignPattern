using System;
using System.Collections.Generic;

namespace CreationalPatterns.Builder.Entities
{
    public class Dragon
    {
        public Dragon( string name, EColor color, IList<Wing> wings, IList<Head> heads, int age, string tail, DateTime? evolutionData, bool master, string feet)
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
        public string Name { get; set; }
        public EColor Color { get; set; }
        public IList<Wing> Wings { get; set; }
        public IList<Head> Heads { get; set;}
        public int Age { get; set; }
        public string Tail { get; set; }
        public DateTime? EvolutionData { get; set; }
        public bool Master { get; set; }
        public string Feet { get; set; }

        public override string ToString()
        {
            return $"Dragão - Dna:{Dna}, Name:{Name}, Color:{Color}, Age:{Age}, Tail:{Tail}, EvolutionData:{EvolutionData}, Master:{Master}, Feet:{Feet}";
        }
    }
}
