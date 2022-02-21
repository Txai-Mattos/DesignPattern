using DesignPatternSamples.BehavioralPatterns.Visitor.Elements;
using DesignPatternSamples.CrossCutting.Extensions;

namespace DesignPatternSamples.BehavioralPatterns.Visitor.Visitors
{
    //ConcreteVisitor2 - implementa os metodos para cada concrete element
    public class ConcreteVisitor2 : IVisitor
    {
        //Não tem necessidade de aramzenar estado interno
        //Implementações dos metodos
        public void Visit(ConcreteEl2 element)
        {
            this.Write($"Visitando o elemento {nameof(ConcreteEl2)}");
        }

        public void Visit(ConcreteEl3 element)
        {
            this.Write($"Visitando o elemento {nameof(ConcreteEl3)}");
            element.DoNothing();
        }

        public void Visit(ConcreteEl1 element)
        {
            this.Write($"Visitando o elemento {nameof(ConcreteEl1)}");
        }
    }
}
