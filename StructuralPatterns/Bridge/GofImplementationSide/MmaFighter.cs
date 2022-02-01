using System;

namespace DesignPatternSamples.StructuralPatterns.Bridge.GofImplementationSide
{
    public class MmaFighter : ISecurity
    {
        public MmaFighter()
        {
        }

        public void BeAlert()
        {
            Console.WriteLine($"{nameof(BeAlert)} - segurança: MmaFighter iniciou a patrulha");
        }

        public void StopVigilance()
        {
            Console.WriteLine($"{nameof(StopVigilance)} - Segurança: MmaFighter foi jogar poker");
        }

        public void RaiseTheAlarme()
        {
            Console.WriteLine($"{nameof(RaiseTheAlarme)} - Segurança: MmaFighter chamou a policia");
        }
        
    }
}
