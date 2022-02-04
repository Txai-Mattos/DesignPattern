using System.Collections.Generic;

namespace DesignPatternSamples.StructuralPatterns.Adapter.Entities.Adapters
{
    //ISale = É o target, a interface do dominio que o cliente tem conhecimento e tem os parametros que ela necessita
    public interface ISale
    {
        //Metodo da interface de dominio que o cliente conhece e sabe se comunicar
        IList<string> ProcessSaleConsolidate(List<SaleDto> sales);
    }
}