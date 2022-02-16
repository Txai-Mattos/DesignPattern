using DesignPatternSamples.BehavioralPatterns.Observer.Observers;
using DesignPatternSamples.CrossCutting.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatternSamples.BehavioralPatterns.Observer.Subjects
{
    //ConcreteSubject -- Envia as notificações aos observadores
    public class Pedido : ISubject
    {
        private List<IObserver> Observers { get; set; }
        private List<SaleProduct> SaleProducts { get; set; }
        private bool Finished { get; set; }
        public int Id { get; }
        public Pedido()
        {
            Observers = new List<IObserver>();
            SaleProducts = new List<SaleProduct>();
            Id = new Random().Next(1, 600);
        }
        //Permitem a inscrição de assinantes ou remoção dos atuais
        public void AddObserver(IObserver observer)
        {
            this.Write($"Adicionando o observador ({observer.GetType().Name})");
            if (!Observers.Contains(observer))
                Observers.Add(observer);
        }
        //Permitem a inscrição de assinantes ou remoção dos atuais
        public void RemoveObserver(IObserver observer)
        {
            this.Write($"Removendo um observador {observer.GetType().Name}");
            if (Observers.Contains(observer))
                Observers.Remove(observer);
        }
        //Notifica aos assinantes, enviando algum dado de contexto para correto tratamento do evento pelo observer
        public void Notify()
        {
            this.Write($"Notificando aos {Observers.Count} observadores sobre a mundança");
            Observers.ForEach(Observer => Observer.Update(SaleProducts));
        }

        //Metodos de regras do proprio subject
        public void Complete()
        {
            if (Finished || !SaleProducts.Any())
                return;

            Finished = true;

            this.Write($"Foi finalizado com {SaleProducts.Count} itens");
            SaleProducts.ForEach(SaleProduct => this.Write($"Item: {SaleProduct}"));
            //Disparando a notificação após mudar o estado
            Notify();
        }
        //Metodos de regras do proprio subject
        public void AddProduct(SaleProduct saleProduct)
        {
            SaleProducts.Add(saleProduct);
        }
    }
}
