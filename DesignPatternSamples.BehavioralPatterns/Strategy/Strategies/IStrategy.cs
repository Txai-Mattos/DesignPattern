using System.Collections.Generic;

namespace DesignPatternSamples.BehavioralPatterns.Strategy.Strategies
{
    //Interface da estrategia
    public interface IStrategy
    {
        void GetNextEmployeeToVacation(List<Employees> funcionarios);
    }
}
