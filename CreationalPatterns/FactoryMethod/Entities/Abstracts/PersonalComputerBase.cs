namespace CreationalPatterns.FactoryMethod
{
    public abstract class PersonalComputerBase
    {
        protected PersonalComputerBase(string name)
        {
            Name = name;
        }

        protected ISytemOperation _SoBase;
        public string LoggedPerson { get; private set; }
        public string Name { get; set; }

        //Factory Method
        public abstract ISytemOperation CreateSytemOperation();

        public void Login(string LoggedPerson)
        {
            //Call factory method
            var sistemaOperacional = CreateSytemOperation();

            sistemaOperacional.Login(LoggedPerson);
        }

    }
}
