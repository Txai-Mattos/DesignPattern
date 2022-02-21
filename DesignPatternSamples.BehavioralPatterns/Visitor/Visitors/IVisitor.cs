using DesignPatternSamples.BehavioralPatterns.Visitor.Elements;

namespace DesignPatternSamples.BehavioralPatterns.Visitor.Visitors
{
    //Classe Visitor - declara o conjunto de métodos visitantes para cada elemento da estrutura de objetos
    public interface IVisitor
    {
        //Metodos visitantes especificos
        void Visit(ConcreteEl2 element);
        void Visit(ConcreteEl3 element);
        void Visit(ConcreteEl1 element);
    }
}
