namespace CreationalPatterns.Builder.Entities
{
    public class Head
    {
        public Head(EColor color, string personality, string power, string horn)
        {
            Color = color;
            Personality = personality;
            Power = power;
            Horn = horn;
        }

        public EColor Color { get; set; }
        public string Personality { get; set; }
        public string Power { get; set; }
        public string Horn { get; set; }
        
    }
}
