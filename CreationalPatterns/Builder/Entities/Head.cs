namespace CreationalPatterns.Builder.Entities
{
    public class Head
    {
        public Head(EColor color, string personality, string power, int horns)
        {
            Color = color;
            Personality = personality;
            Power = power;
            Horns = horns;
        }

        public EColor Color { get; private set; }
        public string Personality { get; private set; }
        public string Power { get; private set; }
        public int Horns { get; private set; }

        public override string ToString()
        {
            return $"Head - Color:{Color}, Personality:{Personality}, Power:{Power}, QtdHorns:{Horns};";
        }
    }
}
