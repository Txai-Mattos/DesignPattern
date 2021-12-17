namespace CreationalPatterns.FactoryMethod
{
    public interface ISytemOperation
    {
        string GetLicence();
        void Login(string loggedPerson);
    }
}