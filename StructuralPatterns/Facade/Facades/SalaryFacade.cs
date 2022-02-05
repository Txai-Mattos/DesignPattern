using DesignPatternSamples.StructuralPatterns.Facade.Subsystem;
using System;

namespace DesignPatternSamples.StructuralPatterns.Facade.Facades
{
    //SalaryFacade: implementação do facade classe que conhece as classes e ordems de chama
    //para os metodos do subsistema
    public class SalaryFacade : IFacade
    {
        //Classes do subsistema de salario
        private readonly OfficerService _officerService;
        private readonly HumanResources _humanResources;
        public SalaryFacade()
        {
            _officerService = new OfficerService();
            _humanResources = new HumanResources();
        }
        //trabalaha diretamento com o subsistema para obter o resultado esperado pelo cliente
        public void ShowSalary(params string[] employees)
        {
            foreach (var employee in employees)
            {
                int branchOffice = _officerService.GetEmployeeBranchOffice(employee);
                int occupation = _officerService.GetEmployeeOccupation(employee);
                if (branchOffice == default || occupation == default)
                {
                    Console.WriteLine($"{employee} - Não é um funcionário");
                    continue;
                }
                var salary = _humanResources.GetSalary(occupation, branchOffice);
                Console.WriteLine($"Funcionário: {employee}, Salario: R${salary:n2}");
            }
        }
    }
}
