namespace DesignPatternSamples.StructuralPatterns.Composite
{
    public abstract class Leaf : HouseComponent
    {
        protected Leaf(string name) : base(name)
        {
        }

        public override bool IsComposite()
            => false;

        public override string Open()
        {
            Status = "Aberto";
            return $"{DrawHierarchy()} - Aberto!!!";
        }
        public override string Close()
        {
            Status = "Fechado";
            return $"{DrawHierarchy()} - Fechado!!!";
        }

        public override string Show()
            => $"{DrawHierarchy()} - {Status}";
    }
}
