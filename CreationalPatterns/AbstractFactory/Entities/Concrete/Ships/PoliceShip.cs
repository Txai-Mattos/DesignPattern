using DesignPatternSamples.CreationalPatterns.AbstractFactory.Entities.Abstracts.Vehicles;

namespace DesignPatternSamples.CreationalPatterns.AbstractFactory.Entities.Concrete.Ships
{
    public class PoliceShip : Ship
    {
        public PoliceShip(int quantityPassenger, int vesselSize, bool canSailInInternationalWaters) : base(quantityPassenger, vesselSize, canSailInInternationalWaters)
        {
        }
    }
}
