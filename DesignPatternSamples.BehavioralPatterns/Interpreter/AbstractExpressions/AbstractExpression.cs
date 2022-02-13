using System;
using System.Collections.Generic;

namespace DesignPatternSamples.BehavioralPatterns.Interpreter.AbstractExpressions
{
    //AbstractExpression: Abstração para todos os nós - opcional utilizei para não repetir código
    public abstract class AbstractExpression : IAbstractExpression
    {
        protected Dictionary<string, int> Hexadecimal = new() { { "A", 10 }, { "B", 11 }, { "C", 12 }, { "D", 13 }, { "E", 14 }, { "F", 15 } };

        public abstract void Interpret(Context context);

        protected int GetDecimalValue(string key, int Multiplier)
        {
            if (!Hexadecimal.TryGetValue(key.ToUpper(), out int result))
                result = int.Parse(key);

            return result * (int)Math.Pow(16, Multiplier);
        }
    }
}
