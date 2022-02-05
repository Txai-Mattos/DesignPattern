using System.Collections.Generic;

namespace DesignPatternSamples.StructuralPatterns.Facade.Subsystem
{
    public class HumanResources
    {
        private readonly Dictionary<string, decimal> _occupationSalary = new Dictionary<string, decimal>()
        {
            {"1-300",7000M},
            {"1-245",10000M },
            {"2-300",7000M},
            {"2-245",10000M }
        };
        private readonly Dictionary<string, string> _employeeName = new Dictionary<string, string>()
        {
            {"10","Ronaldo Nazare"},
            {"123","Raimundo Nonato" }
        };
        public decimal GetSalary(int ocupation, int branchOffice)
        {
            var key = $"{branchOffice}-{ocupation}";
            _occupationSalary.TryGetValue(key, out decimal value);
            return value;
        }

        public string GetEmployeeName(string employee)
        {
            _employeeName.TryGetValue(employee, out string value);
            return value;
        }
    }
}
