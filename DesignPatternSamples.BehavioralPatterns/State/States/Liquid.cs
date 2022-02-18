using DesignPatternSamples.CrossCutting.Extensions;

namespace DesignPatternSamples.BehavioralPatterns.State.States
{
    //Liquid - Estado Concreto
    public class Liquid : IState
    {
        //Metodos para uso do contexto
        public bool CanDrink()
        {
            this.Write($"{nameof(CanDrink)} - pode beber");
            return true;
        }

        public void Freeze(IContext context)
        {
            this.Write($"{nameof(Freeze)} - Esfriou, muda para o estado solido");
            context.ChangeState(new Solid());
        }

        public void WarmUp(IContext context)
        {
            this.Write($"{nameof(WarmUp)} - Esquentou, muda para o estado gasoso");
            context.ChangeState(new Gas());
        }
    }
}
