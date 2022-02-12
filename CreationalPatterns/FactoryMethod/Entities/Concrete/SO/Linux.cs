using DesignPatternSamples.CreationalPatterns.FactoryMethod.Entities.Abstracts;

namespace DesignPatternSamples.CreationalPatterns.FactoryMethod.Entities.Concrete.SO
{
    public class Linux : SOBase
    {
        public override string GetLicence()
            => "De Grátis";
    }
}
