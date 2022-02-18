using DesignPatternSamples.CrossCutting.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatternSamples.BehavioralPatterns.Strategy.Strategies
{
    //Estrategia concreta
    public class FastToReturnStrategy : IStrategy
    {
        //Metodo que roda seu algoritmo
        public void GetNextEmployeeToVacation(List<Employees> funcionarios)
        {
            this.Write($"Selecionado: {funcionarios.OrderBy(x => x.VacationDaysRequested).First().Name}, por desejar menos dias de ferias");
        }
    }
}
