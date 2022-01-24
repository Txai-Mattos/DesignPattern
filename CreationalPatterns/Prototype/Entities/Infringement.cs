using System;

namespace CreationalPatterns.Prototype.Entities
{
    //Using ICloneable interface
    public class Infringement : ICloneable
    {
        public Infringement()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public string Cod { get; set; }
        public int TimeToExpiration { get; set; }

        //ICloneable.Clone returns Object
        public object Clone()
        {
            //Shallow Copy
            return this.MemberwiseClone();
        }

        public override string ToString()
        {
            return $"\nInfringement - Id:{Id}, Cod:{Cod}, Name:{Name}, TimeToExpiration:{TimeToExpiration};";
        }

    }
}