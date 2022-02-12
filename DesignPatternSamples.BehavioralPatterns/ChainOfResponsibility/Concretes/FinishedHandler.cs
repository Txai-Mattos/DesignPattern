using DesignPatternSamples.BehavioralPatterns.ChainOfResponsibility.Abstractions;
using System;
using System.Linq;

namespace DesignPatternSamples.BehavioralPatterns.ChainOfResponsibility.Concretes
{
    //Concrete Handler
    public class FinishedHandler : Handler
    {
        public override void Execute(Context context)
        {
            Console.WriteLine($"{GetType().Name} - Iniciando execução do nó");
            //Checa se não contexto tem o objetos que são tratados por ela
            if (!context.Finished.Any())
            {
                Console.WriteLine($"{GetType().Name} - Este handler não trata o contexto, repassando!");
                //Caso não, chama o proximo nó
                base.Execute(context);
                return;
            }
            //Caso sim, inicia o tratamento
            context.Finished.RemoveAll(x => true);

            Console.WriteLine($"{GetType().Name} - Contexto tratado, finalizando corrente");
        }
    }
}
