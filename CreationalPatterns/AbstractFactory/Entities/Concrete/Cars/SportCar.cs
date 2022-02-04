using DesignPatternSamples.CreationalPatterns.AbstractFactory.Entities.Abstracts.Vehicles;

namespace DesignPatternSamples.CreationalPatterns.AbstractFactory.Entities.Concrete.Cars
{
    public class SportCar : Car
    {
        public SportCar(int quantityPassenger, int wheelQuantity) : base(quantityPassenger, wheelQuantity)
        {
        }
    }
}
