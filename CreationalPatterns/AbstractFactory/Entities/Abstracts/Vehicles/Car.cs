namespace CreationalPatterns.AbstractFactory.Entities.Abstracts.Vehicles
{
    public abstract class Car : Vehicle
    {
        protected Car(int quantityPassenger, int wheelQuantity) : base(quantityPassenger)
        {
            WheelQuantity = wheelQuantity;
        }
        public int WheelQuantity { get; set; }
        public override string ToString()
        {
            return $"Sou um {nameof(Car)} do tipo: {GetType().Name} para {PassengerQuantity} passageiros com {WheelQuantity} Rodas";
        }
    }
}