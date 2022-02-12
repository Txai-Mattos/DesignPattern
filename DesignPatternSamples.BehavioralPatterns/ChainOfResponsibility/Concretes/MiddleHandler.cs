using DesignPatternSamples.BehavioralPatterns.ChainOfResponsibility.Abstractions;
using DesignPatternSamples.CrossCutting.Extensions;
using System.Linq;

namespace DesignPatternSamples.BehavioralPatterns.ChainOfResponsibility.Concretes
{
    //Concrete Handler
    public class MiddleHandler : Handler
    {
        public override void Execute(Context context)
        {
            this.WriteIntoConsole("Iniciando execução do nó");
            //Checa se não contexto tem o objetos que são tratados por ela
            if (!context.Middle.Any())
            {
                this.WriteIntoConsole("Este handler não trata o contexto, repassando!");
                //Caso não, chama o proximo nó
                base.Execute(context);
                return;
            }
            //Caso sim, inicia o tratamento
            context.Finished.AddRange(context.Middle);
            context.Middle.RemoveAll(x => true);

            this.WriteIntoConsole("Contexto tratado, finalizando corrente");
        }
    }
}
