using System;

namespace DesignPatternSamples.StructuralPatterns.Composite
{
    public abstract class HouseComponent : IComponent
    {
        protected HouseComponent(string name)
        {
            Name = name;
            Hierarchy = 1;
        }

        protected string Name { get; set; }
        protected string Status { get; set; }
        protected int Hierarchy { get; set; }

        public abstract string Open();
        public abstract bool IsComposite();
        public virtual void Add(params IComponent[] components)
        {
            if (!IsComposite())
                throw new InvalidOperationException();
        }
        public virtual void Remove(params IComponent[] components)
        {
            if (!IsComposite())
                throw new InvalidOperationException();
        }

        public virtual void SetHierarchy(int hierarchy)
        {
            Hierarchy = hierarchy + 1;
        }
        protected string DrawHierarchy()
            => $"{new string(IsComposite() ? '+' : '-', Hierarchy * 2)}{GetType().Name}/{Name}";

        public abstract string Close();

        public abstract string Show();
    }
}
