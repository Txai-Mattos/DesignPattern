using DesignPatternSamples.CrossCutting.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatternSamples.BehavioralPatterns.Strategy.Strategies
{
    //Estrategia concreta
    public class LongestOverdueStrategy : IStrategy
    {
        //Metodo que roda seu algoritmo
        public void GetNextEmployeeToVacation(List<Employees> funcionarios)
        {
            this.Write($"Selecionado: {funcionarios.OrderBy(x => x.VacationDueDate).First().Name}, por ter ferias vencidas a mais tempo");
        }
    }
}
