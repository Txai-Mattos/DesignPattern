using DesignPatternSamples.CrossCutting.Enums;
using System.Collections.Generic;

namespace DesignPatternSamples.StructuralPatterns.Flyweight.Entities.Flyweights.FlyweightFactories
{
    public static class LampTypeFactory
    {
        private static readonly Dictionary<string, ILampType> _flyweightPool = new();

        public static ILampType GetLampType(EColor color, int power, int lifespan)
        {
            string key = GetKey(color, power, lifespan);
            if (!_flyweightPool.TryGetValue(key, out ILampType lampType))
            {
                lampType = new LedType(color, power, lifespan);
                _flyweightPool.Add(key, lampType);

            }
            return lampType;
        }

        private static string GetKey(EColor color, int power, int lifespan)
         => $"{(int)color}-{power}-{lifespan}";
    }
}
