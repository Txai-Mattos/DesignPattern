using CreationalPatterns.AbstractFactory.Entities.Abstracts.Vehicles;

namespace CreationalPatterns.AbstractFactory.Entities.Concrete.Cars
{
    public class PoliceCar : Car
    {
        public PoliceCar(int quantityPassenger, int wheelQuantity) : base(quantityPassenger, wheelQuantity)
        {
        }
    }
}
