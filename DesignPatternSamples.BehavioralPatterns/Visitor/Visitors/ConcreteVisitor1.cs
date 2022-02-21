using DesignPatternSamples.BehavioralPatterns.Visitor.Elements;
using DesignPatternSamples.CrossCutting.Extensions;

namespace DesignPatternSamples.BehavioralPatterns.Visitor.Visitors
{
    //ConcreteVisitor1 - implementa os metodos para cada concrete element
    public class ConcreteVisitor1 : IVisitor
    {
        //Guarda estado interno que pode ser usado como conteto para os metodos
        private int Count { get; set; }

        //Implementações dos metodos
        public void Visit(ConcreteEl2 element)
        {
            this.Write($"Visitando o elemento nº {Count}(Estado interno do visitante) - {nameof(ConcreteEl2)}");
            element.DoSomething();
            Count++;
        }

        public void Visit(ConcreteEl3 element)
        {
            this.Write($"Visitando o elemento nº {Count}(Estado interno do visitante) - {nameof(ConcreteEl3)}");
            Count++;
        }

        public void Visit(ConcreteEl1 element)
        {
            this.Write($"Visitando o elemento nº {Count}(Estado interno do visitante) - {nameof(ConcreteEl1)}");
            element.ShowAnyThing();
            Count++;
        }
    }
}
