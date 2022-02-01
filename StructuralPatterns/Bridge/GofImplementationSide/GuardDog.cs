using System;

namespace DesignPatternSamples.StructuralPatterns.Bridge.GofImplementationSide
{
    public class GuardDog : ISecurity
    {
        private readonly string AlarmSound = "Au! Au! Au! Au! Au! Au!";
        private string Status;

        public GuardDog()
        {
            Status = "Acordado";
        }

        public void BeAlert()
        {
            Status = "Sangue nos Olhos";
            Console.WriteLine($"{nameof(BeAlert)} - Segurança: GuardDog com o status: {Status}");
        }

        public void StopVigilance()
        {
            Status = "Dormindo";
            Console.WriteLine($"{nameof(StopVigilance)} - Segurança: GuardDog com o status: {Status}");
        }

        public void RaiseTheAlarme()
        {
            Status = "latindo e mordendo";
            Console.WriteLine($"{nameof(RaiseTheAlarme)} - Segurança: GuardDog fazendo o som: {AlarmSound} com o status: {Status}");
        }

        public string GetStatus() => Status;
    }
}
