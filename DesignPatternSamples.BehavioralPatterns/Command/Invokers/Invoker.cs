using DesignPatternSamples.BehavioralPatterns.Command.Commands;
using DesignPatternSamples.CrossCutting.Extensions;
using System.Collections.Generic;

namespace DesignPatternSamples.BehavioralPatterns.Command.Invokers
{
    public class Invoker
    {
        public Invoker()
        {
            _commandsExecuted = new List<ICommand>();
        }
        private ICommand _command;
        private List<ICommand> _commandsExecuted { get; set; }
        public void SetCommand(ICommand command)
        {
            this.WriteIntoConsole($"Associando o comando {command.GetType().Name} ao invoker");
            _command = command;
        }

        public void ExecuteComand()
        {
            this.WriteIntoConsole("O Invoker está chamando o comando");
            _command.Execute();

            _commandsExecuted.Add(_command);
            this.WriteIntoConsole($"O Invoker está armazenou o comando para histórico atualmente com {_commandsExecuted.Count} comandos");
        }
    }
}
