using CreationalPatterns.AbstractFactory.Entities.Abstracts.Vehicles;

namespace CreationalPatterns.AbstractFactory.Entities.Abstracts.Factories
{
    public interface IVehicleFactory
    {
        public Car CreateCar();
        public Airplane CreateAirplane();
        public Ship CreateShip();
    }
}
