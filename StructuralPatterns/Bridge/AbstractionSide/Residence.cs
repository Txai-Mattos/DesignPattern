using DesignPatternSamples.StructuralPatterns.Bridge.ImplementationSide;

namespace DesignPatternSamples.StructuralPatterns.Bridge.AbstractionSide
{
    public abstract class Residence
    {
        protected Residence(bool closed, ISecurity security, bool hasResident)
        {
            Closed = closed;
            Security = security;
            HasResident = hasResident;
        }

        protected ISecurity Security { get; set; }
        protected bool Closed { get; set; }
        protected bool HasResident;

        public abstract void Lock();
        public abstract void Open();
        public abstract void ChangeSecurity(ISecurity security);
        public void ResidentArrived() => HasResident = true;
        public void ResidentLeft() => HasResident = false;
    }
}
