using DesignPatternSamples.CreationalPatterns.AbstractFactory.Entities.Abstracts.Vehicles;

namespace DesignPatternSamples.CreationalPatterns.AbstractFactory.Entities.Concrete.Cars
{
    public class PoliceCar : Car
    {
        public PoliceCar(int quantityPassenger, int wheelQuantity) : base(quantityPassenger, wheelQuantity)
        {
        }
    }
}
