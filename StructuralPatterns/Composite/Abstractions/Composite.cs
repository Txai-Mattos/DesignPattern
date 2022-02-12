using System.Collections.Generic;
using System.Linq;

namespace DesignPatternSamples.StructuralPatterns.Composite.Abstractions
{
    public abstract class Composite : HouseComponent
    {
        protected List<IComponent> _children = new();

        protected Composite(string name) : base(name)
        {
        }

        public override bool IsComposite() => true;

        public override string Open()
        {
            var result = DrawHierarchy();
            _children.ForEach(x =>
            {
                result += $"\n{x.Open()}";
            });
            return result;
        }

        public override string Close()
        {
            var result = DrawHierarchy();
            _children.ForEach(x =>
            {
                result += $"\n{x.Close()}";
            });
            return result;
        }

        public override void Add(params IComponent[] components)
        {
            foreach (var item in components)
            {
                item.SetHierarchy(Hierarchy);
            }
            _children.AddRange(components);
        }

        public override void Remove(params IComponent[] components)
        {
            foreach (var item in components)
            {
                item.SetHierarchy(0);
            }
            _children.RemoveAll(x => components.Contains(x));
        }
        public override void SetHierarchy(int hierarchy)
        {
            Hierarchy = hierarchy + 1;
            _children.ForEach(x => x.SetHierarchy(Hierarchy));
        }

        public override string Show()
        {
            var result = DrawHierarchy();
            _children.ForEach(x =>
            {
                result += $"\n{x.Show()}";
            });
            return result;
        }
    }
}
