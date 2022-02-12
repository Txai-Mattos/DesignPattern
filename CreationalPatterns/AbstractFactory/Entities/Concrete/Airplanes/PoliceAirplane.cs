using DesignPatternSamples.CreationalPatterns.AbstractFactory.Entities.Abstracts.Vehicles;

namespace DesignPatternSamples.CreationalPatterns.AbstractFactory.Entities.Concrete.Airplanes
{
    public class PoliceAirplane : Airplane
    {
        public PoliceAirplane(int passengerQuantity, int maximumFlightAltitude, int maximumFlightSpeed) : base(passengerQuantity, maximumFlightAltitude, maximumFlightSpeed)
        {
        }
    }
}
