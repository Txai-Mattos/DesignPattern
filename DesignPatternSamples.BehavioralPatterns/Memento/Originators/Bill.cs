using DesignPatternSamples.BehavioralPatterns.Memento.Mementos;
using DesignPatternSamples.CrossCutting.Extensions;
using System;

namespace DesignPatternSamples.BehavioralPatterns.Memento.Originators
{
    //Originator
    public class Bill
    {
        public Bill(decimal value, string debtor)
        {
            Number = new Random().Next(1, 600);
            Value = value;
            Debtor = debtor;
            ExpirationDate = DateTime.Now.AddMonths(1);
        }
        //Propiedades ocultas de fora da classe
        private int Discount { get; set; }
        private int Number { get; set; }

        public decimal Value { get; set; }
        public string Debtor { get; set; }
        private DateTime ExpirationDate { get; set; }

        public void SetDiscount(int discount) => Discount = discount;

        public void Show()
        {
            var totalValue = Discount == 0 ? Value : (Value - (Value * Discount /100));
            this.Write($" Numero: {Number}, Devedor: {Debtor}, Valor: R${Value}, Desconto: {Discount}%, Valor Total: R${totalValue}, Data de Validade: {ExpirationDate:d}");
        }
        //Cria o memento
        public IMemento CreateMemento()
        {
            this.Write("Criando o memento");
            return new BillMemento(Number, Value, Discount, Debtor, ExpirationDate);
        }
        //Restaura com base no memento
        public void Restore(IMemento memento)
        {
            this.Write($"restaurando do memento {memento.GetDate():f}");

            if (memento is not BillMemento)
                return;

            var billBackup = memento as BillMemento;


            Number = billBackup.Number;
            Value = billBackup.Value;
            Debtor = billBackup.Debtor;
            ExpirationDate = billBackup.ExpirationDate;
            Discount = billBackup.Discount;
        }
    }
}
