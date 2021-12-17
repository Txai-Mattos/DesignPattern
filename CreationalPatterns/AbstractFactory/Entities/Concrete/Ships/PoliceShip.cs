using CreationalPatterns.AbstractFactory.Entities.Abstracts.Vehicles;

namespace CreationalPatterns.AbstractFactory.Entities.Concrete.Ships
{
    public class PoliceShip : Ship
    {
        public PoliceShip(int quantityPassenger, int vesselSize, bool canSailInInternationalWaters) : base(quantityPassenger, vesselSize, canSailInInternationalWaters)
        {
        }
    }
}
