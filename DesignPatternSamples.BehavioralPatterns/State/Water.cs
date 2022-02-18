using DesignPatternSamples.BehavioralPatterns.State.States;
using DesignPatternSamples.CrossCutting.Extensions;

namespace DesignPatternSamples.BehavioralPatterns.State
{
    //Water - O contexto concreto
    public class Water : IContext
    {
        public int Quantity { get; set; }
        //O vinculo com os estados
        public IState State { get; set; }
        public Water(int quantity)
        {
            //Criando com um estado padrão
            State = new Solid();
            Quantity = quantity;
            this.Write($"Criada agua com o estado {State.GetType().Name} e na quantidade {Quantity} Mls");
        }

        //Metodo para permitir aos estados mudarem o estado atual da water
        public void ChangeState(IState state)
        {
            State = state;
        }
        //Metodos que repassam a trativa ao estado
        public void WarmUp() => State.WarmUp(this);
        public void Freeze() => State.Freeze(this);

        //Metodos que consulta aos estados mais tem suas proprias trativas
        public void Drink(int quantity)
        {
            if (State.CanDrink() && Quantity >= quantity)
            {
                Quantity -= quantity;
                this.Write($"Foi bebido {quantity} Mls sobrando {Quantity} Mls");
            }
        }
    }
}
