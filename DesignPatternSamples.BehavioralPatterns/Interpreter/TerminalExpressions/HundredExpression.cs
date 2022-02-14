using DesignPatternSamples.BehavioralPatterns.Interpreter.AbstractExpressions;
using DesignPatternSamples.CrossCutting.Extensions;

namespace DesignPatternSamples.BehavioralPatterns.Interpreter.TerminalExpressions
{
    //TerminalExpression
    public class HundredExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            if (context.Expression.Length != 3)
                return;

            var value = context.Expression[..1];
            var decValue = GetDecimalValue(value, 2);
            context.Output += decValue;

            this.Write($"entrada {context.Expression} Saida {context.Output}");
            context.Expression = context.Expression[1..];
        }
    }
}
