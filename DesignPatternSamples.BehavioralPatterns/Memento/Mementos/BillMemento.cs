using System;

namespace DesignPatternSamples.BehavioralPatterns.Memento.Mementos
{
    //Memento
    public class BillMemento : IMemento
    {
        public BillMemento(int number, decimal value, int discount, string debtor, DateTime expirationDate)
        {
            Number = number;
            Value = value;
            Discount = discount;
            Debtor = debtor;
            ExpirationDate = expirationDate;
            CreatedDate = DateTime.Now;
            Id = Guid.NewGuid();
        }
        private DateTime CreatedDate { get; }
        public int Number { get; }
        public decimal Value { get; }
        public int Discount { get; }
        public string Debtor { get; }
        public DateTime ExpirationDate { get; }
        public Guid Id { get; }

        //Metodos para metadados
        public DateTime GetDate()
         => CreatedDate;
        //Metodos para metadados
        public Guid GetGuid()
        => Id;
    }
}
