﻿using DesignPatternSamples.BehavioralPatterns.Visitor.Visitors;
using DesignPatternSamples.CrossCutting.Extensions;

namespace DesignPatternSamples.BehavioralPatterns.Visitor.Elements
{
    //ConcreteElement: Implementa o IElement
    public class ConcreteEl2 : IElement
    {
        //Implementa o metodo de aceite do visitor
        public void Accept(IVisitor visitor)
        {
            //Chama o metodo especifico do visitor que trata ele
            visitor.Visit(this);
        }
        //Pode ter seus metodos espeficos, para consulta ou requisição dos visitors
        public void DoSomething()
        {
            this.Write($"{nameof(DoSomething)} Fazendo algo");
        }
    }
}
