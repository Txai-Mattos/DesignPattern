namespace DesignPatternSamples.BehavioralPatterns.Command
{
    public class ConcreteCommand : ICommand
    {
        private readonly Receiver _receiver;
        public ConcreteCommand(Receiver receiver)
        {
            _receiver = receiver;
        }

        public void Execute()
        {
            _receiver.DoSomeThing();
        }
    }
}
