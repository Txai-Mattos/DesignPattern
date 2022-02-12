using DesignPatternSamples.CrossCutting.Enums;

namespace DesignPatternSamples.CreationalPatterns.Builder.Entities.Builders
{
    public class WingBuilder
    {
        private EColor _color;
        private int _velocity;
        private int _highestAltitude;

        public WingBuilder() { }

        public WingBuilder WithColor(EColor color)
        {
            _color = color;
            return this;
        }

        public WingBuilder WithVelocity(int velocity)
        {
            _velocity = velocity;
            return this;
        }

        public WingBuilder WithHighestAltitude(int highestAltitude)
        {
            _highestAltitude = highestAltitude;
            return this;
        }

        public Wing Build()
        {
            return new Wing(_color, _velocity, _highestAltitude);
        }
    }
}
