using System;

namespace DesignPatternSamples.CreationalPatterns.FactoryMethod.Entities.Abstracts
{
    public abstract class SOBase : ISytemOperation
    {
        private string LoggedPerson { get; set; }

        public abstract string GetLicence();
        public virtual void Login(string loggedPerson)
        {
            LoggedPerson = loggedPerson;
            Console.WriteLine($"Logando o {LoggedPerson} no SO: {GetType().Name} de Licensa {GetLicence()}");
        }
    }
}