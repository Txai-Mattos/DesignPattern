namespace DesignPatternSamples.CreationalPatterns.AbstractFactory.Entities.Abstracts.Vehicles
{
    public abstract class Airplane : Vehicle
    {
        protected Airplane(int passengerQuantity, int maximumFlightAltitude, int maximumFlightSpeed) : base(passengerQuantity)
        {
            MaximumFlightSpeed = maximumFlightSpeed;
            MaximumFlightAltitude = maximumFlightAltitude;
        }

        public int MaximumFlightAltitude { get; }
        public int MaximumFlightSpeed { get; }

        public override string ToString()
        {
            return $"Sou um {nameof(Airplane)} do tipo: {GetType().Name} para {PassengerQuantity} passageiros com altitude maxima de {MaximumFlightAltitude} Pés e velocidade {MaximumFlightSpeed}KM/H";
        }
    }
}