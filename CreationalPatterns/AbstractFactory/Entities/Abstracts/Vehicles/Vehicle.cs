namespace DesignPatternSamples.CreationalPatterns.AbstractFactory.Entities.Abstracts.Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(int passengerQuantity)
        {
            PassengerQuantity = passengerQuantity;
        }

        protected int PassengerQuantity { get; }
    }
}
