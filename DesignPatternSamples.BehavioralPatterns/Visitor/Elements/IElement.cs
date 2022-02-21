using DesignPatternSamples.BehavioralPatterns.Visitor.Visitors;

namespace DesignPatternSamples.BehavioralPatterns.Visitor.Elements
{
    //IElement - interface para aceitar os visitor atráves da interface deles
    public interface IElement
    {
        //Metodo para acetar o visitor
        void Accept(IVisitor visitor);
    }
}
