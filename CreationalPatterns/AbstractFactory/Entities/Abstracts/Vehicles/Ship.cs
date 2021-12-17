namespace CreationalPatterns.AbstractFactory.Entities.Abstracts.Vehicles
{
    public abstract class Ship : Vehicle
    {
        protected Ship(int quantityPassenger, int vesselSize, bool canSailInInternationalWaters) : base(quantityPassenger)
        {
            VesselSize = vesselSize;
            CanSailInInternationalWaters = canSailInInternationalWaters;
        }
        public int VesselSize { get; }
        public bool CanSailInInternationalWaters { get; }
        public override string ToString()
        {
            var apresentation = $"Sou um {nameof(Ship)} do tipo: {GetType().Name} para {PassengerQuantity} passageiros de tamanho {VesselSize} metros";
            if (CanSailInInternationalWaters)
                apresentation = $"{apresentation} e posso navegar em aguas internacionais";

            return apresentation;
        }
    }
}