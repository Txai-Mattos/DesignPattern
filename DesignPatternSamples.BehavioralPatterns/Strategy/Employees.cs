using System;

namespace DesignPatternSamples.BehavioralPatterns.Strategy
{
    public class Employees
    {
        public Employees(string name, int vacationDaysRequested, DateTime admissionDate, DateTime vacationDueDate)
        {
            Name = name;
            VacationDaysRequested = vacationDaysRequested;
            AdmissionDate = admissionDate;
            VacationDueDate = vacationDueDate;
        }
        public string Name { get; set; }
        public int VacationDaysRequested { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime VacationDueDate { get; set; }

        public override string ToString()
        {
            return $"Nome: {Name}, Dias Solicitados {VacationDaysRequested}, Data de Adimissão {AdmissionDate:d}, Ferias vencidas em {VacationDueDate:d}";
        }
    }
}
