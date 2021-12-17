using CreationalPatterns.AbstractFactory.Entities.Abstracts.Vehicles;

namespace CreationalPatterns.AbstractFactory.Entities.Concrete.Cars
{
    public class SportCar : Car
    {
        public SportCar(int quantityPassenger, int wheelQuantity) : base(quantityPassenger, wheelQuantity)
        {
        }
    }
}
