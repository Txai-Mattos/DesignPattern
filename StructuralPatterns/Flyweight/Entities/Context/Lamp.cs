using DesignPatternSamples.StructuralPatterns.Flyweight.Entities.Flyweights;

namespace DesignPatternSamples.StructuralPatterns.Flyweight.Entities.Context
{
    public class Lamp
    {
        public Lamp(ILampType lampType, int positionX, int positionY)
        {
            LampType = lampType;
            PositionX = positionX;
            PositionY = positionY;
        }
        //Campos extrínsecos
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public bool PowerOn { get; set; }
        //referencia ao Flyweight
        public ILampType LampType { get; set; }

        public void TurnOn()
        {
            //Chamando metodo do flyweight passando os dados extrínsecas por paramentro
            LampType.TurnOn(PositionX, PositionY);
            PowerOn = true;
        }
    }
}
