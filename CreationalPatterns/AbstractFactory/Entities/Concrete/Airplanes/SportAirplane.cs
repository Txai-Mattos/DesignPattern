using CreationalPatterns.AbstractFactory.Entities.Abstracts.Vehicles;

namespace CreationalPatterns.AbstractFactory.Entities.Concrete.Airplanes
{
    public class SportAirplane : Airplane
    {
        public SportAirplane(int passengerQuantity, int maximumFlightAltitude, int maximumFlightSpeed) : base(passengerQuantity, maximumFlightAltitude, maximumFlightSpeed)
        {
        }
    }
}
