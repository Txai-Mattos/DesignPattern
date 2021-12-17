namespace CreationalPatterns.FactoryMethod.Entites.Concrete.PC
{
    public class OfficePC : PersonalComputerBase
    {
        public OfficePC(string name) : base(name)
        {
        }

        public override ISytemOperation CreateSytemOperation()
        {
            if (_SoBase == default)
            {
                _SoBase = new Windows();
            }
            return _SoBase;
        }
            
    }
}
