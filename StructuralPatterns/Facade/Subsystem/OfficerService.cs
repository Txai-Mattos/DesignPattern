using System.Collections.Generic;

namespace DesignPatternSamples.StructuralPatterns.Facade.Subsystem
{
    public class OfficerService
    {
        private readonly Dictionary<string, int> _employeeBranchOffice = new Dictionary<string, int>()
        {
            {"10",1},
            {"123",2 }
        };
        private readonly Dictionary<string, int> _employeeOccupation = new Dictionary<string, int>()
        {
            {"10", 300},
            {"123",245 }
        };

        public int GetEmployeeBranchOffice(string employee)
        {
            _employeeBranchOffice.TryGetValue(employee, out int value);
            return value;
        }
        public int GetEmployeeOccupation(string employee)
        {
            _employeeOccupation.TryGetValue(employee, out int value);
            return value;
        }
    }
}
