using DesignPatternSamples.CrossCutting.Extensions;
using System;
using System.Collections.Generic;

namespace DesignPatternSamples.BehavioralPatterns.Command
{
    public class AlertCommand : ICommand
    {
        private readonly PromotionService _receiver;
        private readonly List<string> _clients;
        private readonly DateTime _expirationDate;
        private readonly string _department;
        public AlertCommand(PromotionService receiver, List<string> clients, DateTime expirationDate, string department)
        {
            _receiver = receiver;
            _clients = clients;
            _expirationDate = expirationDate;
            _department = department;
            this.WriteIntoConsole($"criado comando: Clientes: {string.Join(',', _clients)}, Validade: {_expirationDate:d}, Departamento: {_department}\n");
        }

        public void Execute()
        {
            this.WriteIntoConsole("O comando está chamando o receiver, passando seus respectivos parâmentros");
            _receiver.SendPromotionVoucher(_clients, _expirationDate, _department);
        }
    }
}
