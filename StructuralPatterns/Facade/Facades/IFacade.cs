namespace DesignPatternSamples.StructuralPatterns.Facade.Facades
{
    //IFacade: interface simplicada para o subsistema de salarios
    public interface IFacade
    {
        //Expôem um comportamento simplicado padrão para a consulta de salarios
        void ShowSalary(params string[] employees);
    }
}
