namespace DesignPatternSamples.CreationalPatterns.FactoryMethod.Entities.Abstracts
{
    public interface ISytemOperation
    {
        string GetLicence();
        void Login(string loggedPerson);
    }
}