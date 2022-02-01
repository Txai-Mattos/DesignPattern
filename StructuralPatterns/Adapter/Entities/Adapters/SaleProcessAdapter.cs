using CrossCutting.Extensions;
using StructuralPatterns.Adapter.Entities.Adaptees;
using System.Collections.Generic;
using System.Linq;

namespace StructuralPatterns.Adapter.Entities.Adapters
{
    // SaleProcessAdapter = O adaptador que torna a interface Adaptada compatível com a interface do dominio
    public class SaleProcessAdapter : ISale
    {
        //IQuarterConsolidade = a interface adpatada nesse caso poderia ser uma interface terceira ou uma lib que não temos acesso
        private readonly IQuarterConsolidade _adaptee;

        public SaleProcessAdapter(IQuarterConsolidade adaptee)
        {
            _adaptee = adaptee;
        }

        //Metodo de conhecimento do dominio
        public IList<string> ProcessSaleConsolidate(List<SaleDto> sales)
        {
            //convert os dados de entrada para torna-lo compatível com a interface adptada
            //QuarterDto = Objeto necessário para classe adaptada
            var quarterSales = sales.Select(x => new QuarterDto { Value = x.Value, Quarter = x.Date.GetQuarter() }).ToList();

            //Chama a interface adpatada para realizar o processamento efetivo
            var consolidadeValues = _adaptee.ConsolidateSalesByQuarter(quarterSales);

            //convert os dados retornados pela interface adaptada para ser compatível com o retorno da interface do dominio do client
            return consolidadeValues.Select(x => $"Quarter: {x.Quarter} - R$ {x.ConsolidadeValue:n2}").ToList();
        }
    }
}
