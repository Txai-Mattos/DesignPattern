using System.Collections.Generic;

namespace DesignPatternSamples.StructuralPatterns.Flyweight.Entities.Context
{
    public class Shed
    {
        public List<Lamp> Lamps { get; set; }

        public void SetLamps(params Lamp[] lamps)
        {
            Lamps.AddRange(lamps);
        }

        public void TurnOnLamps()
        {
            Lamps.ForEach(l => l.TurnOn());
        }
        public Shed()
        {
            Lamps = new List<Lamp>();
        }
    }
}
