using DesignPatternSamples.BehavioralPatterns.Strategy.Strategies;
using DesignPatternSamples.CrossCutting.Extensions;
using System;
using System.Collections.Generic;

namespace DesignPatternSamples.BehavioralPatterns.Strategy
{
    //Classe de contexto
    public class VacationService
    {
        public VacationService(IStrategy strategy)
        {
            Funcionarios = new List<Employees>()
            {
                new("Lay", 30, new DateTime(2016,02,15), new DateTime(2022,01,15)),
                new("Luan", 20, new DateTime(2019,02,25), new DateTime(2021,05,16)),
                new("Rai", 10, new DateTime(2020,04,20), new DateTime(2022,02,15)),
                new("Zezo", 15, new DateTime(2018,05,10), new DateTime(2021,06,23)),
            };
            Strategy = strategy;
        }
        private IStrategy Strategy { get; set; }
        private List<Employees> Funcionarios { get; set; }

        public void ShowEmployees()
        {
            this.Write("Exibindo os funcionarios candidatos");
            Funcionarios.ForEach(x => this.Write(x.ToString()));
        }
        public void ChangeStrategy(IStrategy strategy)
        {
            this.Write($"Mudando a estrategia para {strategy.GetType().Name}", "\n");
            Strategy = strategy;
        }
        //delegando a responsábilidade para a estrátegia
        public void CalculateNextEmployeeToVacation()
        {
            this.Write("Passando para a estrategia a responsabilidade para descobrir o proximo funcionário");
            Strategy.GetNextEmployeeToVacation(Funcionarios);
        }
    }
}
