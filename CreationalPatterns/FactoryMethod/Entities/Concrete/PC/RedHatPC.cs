namespace CreationalPatterns.FactoryMethod.Entites.Concrete.PC
{
    public class RedHatPC : PersonalComputerBase
    {
        public RedHatPC(string name) : base(name)
        {
        }

        public override ISytemOperation CreateSytemOperation()
        {
            if (_SoBase == default)
            {
                _SoBase = new Linux();
            }
            return _SoBase;
        }
    }
}
