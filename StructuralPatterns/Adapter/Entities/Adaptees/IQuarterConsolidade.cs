using System.Collections.Generic;

namespace StructuralPatterns.Adapter.Entities.Adaptees
{
    //IQuarterConsolidade = Adaptee a interface que será adpatada pois o cliente não conhece o "QuarterDto" que é passado
    public interface IQuarterConsolidade
    {
        //Metodo que será adpatado o cliente não conhece o "QuarterDto" que é passado e retornado por ele
        List<QuarterDto> ConsolidateSalesByQuarter(List<QuarterDto> quarterSales);
    }
}
