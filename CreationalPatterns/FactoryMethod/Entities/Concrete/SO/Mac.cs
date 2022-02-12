using DesignPatternSamples.CreationalPatterns.FactoryMethod.Entities.Abstracts;
using System;

namespace DesignPatternSamples.CreationalPatterns.FactoryMethod.Entities.Concrete.SO
{
    public class Mac : SOBase
    {
        public override string GetLicence()
            => "Paga";

        public override void Login(string loggedPerson)
        {
            if (loggedPerson.Equals("ADMIN"))
            {
                Console.WriteLine($"O usuário {loggedPerson} não tem permissão para logar no SO:{GetType().Name} de Licensa {GetLicence()}");
                return;
            }
            base.Login(loggedPerson);
        }

    }
}
