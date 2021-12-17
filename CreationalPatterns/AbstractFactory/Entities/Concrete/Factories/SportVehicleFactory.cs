using CreationalPatterns.AbstractFactory.Entities.Abstracts.Factories;
using CreationalPatterns.AbstractFactory.Entities.Abstracts.Vehicles;
using CreationalPatterns.AbstractFactory.Entities.Concrete.Airplanes;
using CreationalPatterns.AbstractFactory.Entities.Concrete.Cars;
using CreationalPatterns.AbstractFactory.Entities.Concrete.Ships;

namespace CreationalPatterns.AbstractFactory.Entities.Concrete.Factories
{
    //Abstract Factory Concrete
    public class SportVehicleFactory : VehicleFactory
    {
        public override Airplane CreateAirplane()
        {
            return new SportAirplane(12,5000,2500);
        }

        public override Car CreateCar()
        {
            return new SportCar(2,6);
        }

        public override Ship CreateShip()
        {
            return new SportShip(4,50,true);
        }
    }
}
