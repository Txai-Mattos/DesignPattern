using CreationalPatterns.Builder.Entities.Builders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CreationalPatterns.Builder.Entities
{
    public class DragonBuilder
    {
        private string _name;
        private EColor _color;
        private IList<Wing> _wings;
        private IList<Head> _heads = new List<Head>();
        private int _age;
        private string _tail;
        private DateTime? _evolutionData;
        private bool _master;
        private string _feet;

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

        //Recebendo o "HeadBuilder" e contruindo dentro construido fora
        public DragonBuilder WithHead(Action<HeadBuilder> lazyBuilder)
        {
            var HeadBuilder = new HeadBuilder();            
            lazyBuilder(HeadBuilder);

            _heads.Add(HeadBuilder.Build());
            return this;
        }

        //Recebendo o "Wing"´já construido fora
        public DragonBuilder WithWing(Wing wing)
        {
            if (_wings == default || !_wings.Any())
                _wings = new List<Wing>();
            
            _wings.Add(wing);
            return this;
        }
    }
}
