using System.Collections.Generic;

namespace DesignPatternSamples.BehavioralPatterns.Observer.Observers
{
    //Interface do objeto assinante
    public interface IObserver
    {
        //Metodo para receber a notificação, pode receber o proprio objeto subject ou algum dado de contexto
        void Update(List<SaleProduct> saleProducts);
    }
}
