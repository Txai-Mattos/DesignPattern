using DesignPatternSamples.CrossCutting.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatternSamples.BehavioralPatterns.Observer.Observers
{
    //ConcreteObserver - Observador concreto vai reagir as mundaças do subject de acordo com usas regras
    public class Separation : IObserver
    {
        //Metodo de update recebendo contexto do subject
        public void Update(List<SaleProduct> saleProducts)
        {
            Console.WriteLine();
            this.Write("Foi Sinalizado da mudança pelo subject e esta reagindo de acordo a suas regras");
            foreach (var item in saleProducts.Where(x => x.Amount > 10))
            {
                SeparateProduct(item);
            }
        }

        public void SeparateProduct(SaleProduct saleProduct) => this.Write($"Separando o produto com mais de dez itens para entrega: {saleProduct} ");
    }
}
