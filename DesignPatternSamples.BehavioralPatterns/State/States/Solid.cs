using DesignPatternSamples.CrossCutting.Extensions;

namespace DesignPatternSamples.BehavioralPatterns.State.States
{
    //Solid - Estado Concreto
    public class Solid : IState
    {
        //Metodos para uso do contexto
        public bool CanDrink()
        {
            this.Write($"{nameof(CanDrink)} - Não é possível beber a agua pois ela está solida, esquente antes");
            return false;
        }

        public void Freeze(IContext contex)
        {
            this.Write($"{nameof(Freeze)} - Esfriou, continua no estado Solido");
        }

        public void WarmUp(IContext context)
        {
            this.Write($"{nameof(WarmUp)} - Esquentou, muda para o estado liquido");
            context.ChangeState(new Liquid());
        }
    }
}
