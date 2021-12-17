using System;
using System.Collections.Generic;

namespace CreationalPatterns.Builder.Entities
{
    public class DragonBuilder
    {
        private string _name { get; set; }
        private EColor _color { get; set; }
        private IList<Wing> _wings { get; set; }
        private IList<Head> _heads { get; set; }
        private int _age { get; set; }
        private string _tail { get; set; }
        private DateTime? _evolutionData { get; set; }
        private bool _master { get; set; }
        private string _feet { get; set; }

        public Dragon Build()
        {

            return new Dragon(_name, _color, _wings, _heads, _age, _tail, _evolutionData, _master, _feet);
        }

        public DragonBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public DragonBuilder WithColor(EColor color)
        {
            _color = color;
            return this;
        }

        public DragonBuilder WithAge(int age)
        {
            _age = age;
            return this;
        }

        public DragonBuilder WithTail(string tail)
        {
            _tail = tail;
            return this;
        }

        public DragonBuilder WithMaster(bool master)
        {
            _master = master;
            return this;
        }

        public DragonBuilder WithEvolutionData(DateTime evolutionData)
        {
            _evolutionData = evolutionData;
            return this;
        }

        public DragonBuilder WithFeet(string feet)
        {
            _feet = feet;
            return this;
        }
    }
}
