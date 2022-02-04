using DesignPatternSamples.CreationalPatterns.AbstractFactory.Entities.Abstracts.Vehicles;

namespace DesignPatternSamples.CreationalPatterns.AbstractFactory.Entities.Abstracts.Factories
{
    public interface IVehicleFactory
    {
        public Car CreateCar();
        public Airplane CreateAirplane();
        public Ship CreateShip();
    }
}
