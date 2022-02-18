using DesignPatternSamples.CrossCutting.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatternSamples.BehavioralPatterns.Strategy.Strategies
{
    //Estrategia concreta
    public class TimeInCompanyStrategy : IStrategy
    {
        //Metodo que roda seu algoritmo
        public void GetNextEmployeeToVacation(List<Employees> funcionarios)
        {
            this.Write($"Selecionado: {funcionarios.OrderBy(x => x.AdmissionDate).First().Name}, por maior tempo de empresa");
        }
    }
}
