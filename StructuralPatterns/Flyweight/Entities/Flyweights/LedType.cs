using DesignPatternSamples.CrossCutting.Enums;
using DesignPatternSamples.CrossCutting.Extensions;

namespace DesignPatternSamples.StructuralPatterns.Flyweight.Entities.Flyweights
{
    //ConcreteFlyweight
    public class LedType : ILampType
    {
        public LedType(EColor color, int power, int lifespan)
        {
            Color = color;
            Power = power;
            Lifespan = lifespan;
            this.WriteIntoConsole($"Criando novo Tipo de lampada com os valores: {this}");
        }
        public EColor Color { get; }
        public int Power { get; }
        public int Lifespan { get; }

        //Metodo do flyweight passando os dados extrínsecas por paramentro
        public void TurnOn(int x, int y)
        {
            this.WriteIntoConsole($"Ligado na posição {x} - {y}, {this}");
        }

        public override string ToString()
            => $"Color( {Color} ), Power( {Power}W ), LifeSpan({Lifespan}hrs)";

    }
}
