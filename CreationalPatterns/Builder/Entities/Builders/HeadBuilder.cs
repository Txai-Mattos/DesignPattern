using DesignPatternSamples.CrossCutting.Enums;

namespace DesignPatternSamples.CreationalPatterns.Builder.Entities.Builders
{
    public class HeadBuilder
    {
        private EColor _color;
        private string _personality;
        private string _power;
        private int _horns;

        public HeadBuilder() { }

        public HeadBuilder WithColor(EColor color)
        {
            _color = color;
            return this;
        }

        public HeadBuilder WithPersonality(string personality)
        {
            _personality = personality;
            return this;
        }

        public HeadBuilder WithPower(string power)
        {
            _power = power;
            return this;
        }

        public HeadBuilder WithHorn(int horns)
        {
            _horns = horns;
            return this;
        }

        public Head Build()
        {
            return new Head(_color, _personality, _power, _horns);
        }
    }
}
