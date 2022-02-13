namespace DesignPatternSamples.BehavioralPatterns.Interpreter
{
    //Context
    public class Context
    {
        public Context(string expression)
        {
            Expression = expression;
        }
        public string Expression { get; set; }
        public int Output { get; set; }
    }
}
