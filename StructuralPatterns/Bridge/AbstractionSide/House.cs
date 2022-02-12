using DesignPatternSamples.StructuralPatterns.Bridge.ImplementationSide;
using System;

namespace DesignPatternSamples.StructuralPatterns.Bridge.AbstractionSide
{
    public class House : Residence
    {
        public House(bool closed, ISecurity security, bool hasResident) : base(closed, security, hasResident)
        {
        }

        public override void ChangeSecurity(ISecurity security)
            => Security = security;

        public override void Lock()
        {
            if (!Closed)
            {
                Console.WriteLine("A casa foi trancada");
                Security.BeAlert();
                Closed = true;
                return;
            }
            Console.WriteLine("A casa já estava trancada");
        }

        public override void Open()
        {
            if (HasResident)
            {
                Console.WriteLine($"A casa foi aberta");
                Security.StopVigilance();
                Closed = false;
            }
            else
            {
                Console.WriteLine($"A casa teve violação de segurança");
                Security.RaiseTheAlarme();
            }
        }
    }
}
