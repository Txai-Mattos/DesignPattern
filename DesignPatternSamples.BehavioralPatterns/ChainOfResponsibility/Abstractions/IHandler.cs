namespace DesignPatternSamples.BehavioralPatterns.ChainOfResponsibility.Abstractions
{
    public interface IHandler
    {
        //Metodo para tratar a requisição
        void Execute(Context context);
        //Metodos para adicionar o proximo laço da corrente
        IHandler SetNext(IHandler handler);
    }
}
