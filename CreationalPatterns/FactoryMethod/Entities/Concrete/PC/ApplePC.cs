using DesignPatternSamples.CreationalPatterns.FactoryMethod.Entities.Abstracts;
using DesignPatternSamples.CreationalPatterns.FactoryMethod.Entities.Concrete.SO;

namespace DesignPatternSamples.CreationalPatterns.FactoryMethod.Entities.Concrete.PC
{
    public class ApplePC : PersonalComputerBase
    {
        public ApplePC(string name) : base(name)
        {
        }

        public override ISytemOperation CreateSytemOperation()
        {
            if (_SoBase == default)
            {
                _SoBase = new Mac();
            }
            return _SoBase;
        }
    }
}
