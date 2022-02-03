namespace DesignPatternSamples.StructuralPatterns.Composite
{
    public interface IComponent
    {
        void SetHierarchy(int hierarchy);
        string Open();
        string Show();
        string Close();
        bool IsComposite();
        void Add(params IComponent[] components);
        void Remove(params IComponent[] components);
    }
}
