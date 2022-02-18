using DesignPatternSamples.CrossCutting.Extensions;

namespace DesignPatternSamples.BehavioralPatterns.State.States
{
    //Gas - Estado Concreto
    public class Gas : IState
    {
        //Metodos para uso do contexto
        public bool CanDrink()
        {
            this.Write($"{nameof(CanDrink)} - Não é possível beber a agua pois ela está gasosa, esfrie antes");
            return false;
        }

        public void Freeze(IContext context)
        {
            this.Write($"{nameof(Freeze)} - esfriou, muda para o estado Liquido");
            context.ChangeState(new Liquid());
        }

        public void WarmUp(IContext context)
        {
            this.Write($"{nameof(WarmUp)} - Esquentou, continua no estado gasoso");
        }
    }
}
