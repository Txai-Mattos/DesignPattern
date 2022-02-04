using DesignPatternSamples.CreationalPatterns.AbstractFactory.Entities.Abstracts.Factories;
using DesignPatternSamples.CreationalPatterns.AbstractFactory.Entities.Abstracts.Vehicles;
using DesignPatternSamples.CreationalPatterns.AbstractFactory.Entities.Concrete.Airplanes;
using DesignPatternSamples.CreationalPatterns.AbstractFactory.Entities.Concrete.Cars;
using DesignPatternSamples.CreationalPatterns.AbstractFactory.Entities.Concrete.Ships;

namespace DesignPatternSamples.CreationalPatterns.AbstractFactory.Entities.Concrete.Factories
{
    //Abstract Factory Concrete
    public class PoliceVehicleFactory : VehicleFactory
    {
        public override Airplane CreateAirplane()
        {
            return new PoliceAirplane(100, 8000, 500);
        }

        public override Car CreateCar()
        {
            return new PoliceCar(18, 4);
        }

        public override Ship CreateShip()
        {
            return new PoliceShip(20, 80, false);
        }
    }
}
