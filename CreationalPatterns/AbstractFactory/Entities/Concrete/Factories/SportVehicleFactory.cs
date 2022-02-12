using DesignPatternSamples.CreationalPatterns.AbstractFactory.Entities.Abstracts.Factories;
using DesignPatternSamples.CreationalPatterns.AbstractFactory.Entities.Abstracts.Vehicles;
using DesignPatternSamples.CreationalPatterns.AbstractFactory.Entities.Concrete.Airplanes;
using DesignPatternSamples.CreationalPatterns.AbstractFactory.Entities.Concrete.Cars;
using DesignPatternSamples.CreationalPatterns.AbstractFactory.Entities.Concrete.Ships;

namespace DesignPatternSamples.CreationalPatterns.AbstractFactory.Entities.Concrete.Factories
{
    //Abstract Factory Concrete
    public class SportVehicleFactory : VehicleFactory
    {
        public override Airplane CreateAirplane()
        {
            return new SportAirplane(12, 5000, 2500);
        }

        public override Car CreateCar()
        {
            return new SportCar(2, 6);
        }

        public override Ship CreateShip()
        {
            return new SportShip(4, 50, true);
        }
    }
}
