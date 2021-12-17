using CreationalPatterns.AbstractFactory.Entities.Abstracts.Vehicles;

namespace CreationalPatterns.AbstractFactory.Entities.Concrete.Ships
{
    public class SportShip : Ship
    {
        public SportShip(int quantityPassenger, int vesselSize, bool canSailInInternationalWaters) : base(quantityPassenger, vesselSize, canSailInInternationalWaters)
        {
        }
    }
}
