using DesignPatternSamples.CrossCutting.Enums;

namespace DesignPatternSamples.CreationalPatterns.Builder.Entities
{
    public class Wing
    {
        public Wing(EColor color, int velocity, int highestAltitude)
        {
            Color = color;
            Velocity = velocity;
            HighestAltitude = highestAltitude;
        }

        public EColor Color { get; private set; }
        public int Velocity { get; private set; }
        public int HighestAltitude { get; private set; }

        public override string ToString()
        {
            return $"Wing - Color:{Color}, Velocity:{Velocity}Km/h, HighestAltitude:{HighestAltitude}Mts";
        }
    }
}
