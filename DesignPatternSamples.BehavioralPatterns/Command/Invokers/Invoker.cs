using DesignPatternSamples.BehavioralPatterns.Command.Commands;
using DesignPatternSamples.CrossCutting.Extensions;
using System.Collections.Generic;

namespace DesignPatternSamples.BehavioralPatterns.Command.Invokers
{
    public class Invoker
    {
        public Invoker()
        {
            CommandsExecuted = new List<ICommand>();
        }
        private ICommand _command;
        private List<ICommand> CommandsExecuted { get; set; }
        public void SetCommand(ICommand command)
        {
            this.Write($"Associando o comando {command.GetType().Name} ao invoker");
            _command = command;
        }

        public void ExecuteComand()
        {
            this.Write("O Invoker está chamando o comando");
            _command.Execute();

            CommandsExecuted.Add(_command);
            this.Write($"O Invoker está armazenou o comando para histórico atualmente com {CommandsExecuted.Count} comandos");
        }
    }
}
