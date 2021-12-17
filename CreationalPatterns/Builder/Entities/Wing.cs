namespace CreationalPatterns.Builder.Entities
{
    public class Wing
    {
        public Wing(EColor color, int velocity, int highestAltitude, string horn)
        {
            Color = color;
            Velocity = velocity;
            HighestAltitude = highestAltitude;
            Horn = horn;
        }

        public EColor Color { get; set; }
        public int Velocity { get; set; }
        public int HighestAltitude { get; set; }
        public string Horn { get; set; }
    }
}
