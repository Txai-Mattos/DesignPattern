using System.Collections.Generic;
using System.Linq;

namespace DesignPatternSamples.StructuralPatterns.Adapter.Entities.Adaptees
{
    //QuarterConsolidade = Adaptee O concreto que será adpatada pois o cliente não conhece o "QuarterDto" que é passado
    public class QuarterConsolidade : IQuarterConsolidade
    {
        //Metodo que será adpatado o cliente não conhece o "QuarterDto" que é passado e retornado por ele
        public List<QuarterDto> ConsolidateSalesByQuarter(List<QuarterDto> quarterSales)
        {
            //Processamento efetivo da consolidação das vendas
            var consolidadeList = quarterSales.GroupBy(x => x.Quarter).Select(x => new QuarterDto { Quarter = x.Key, ConsolidadeValue = x.Sum(y => y.Value) }).ToList();

            return consolidadeList;
        }
    }
}
