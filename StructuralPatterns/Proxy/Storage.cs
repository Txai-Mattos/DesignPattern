using System;

namespace DesignPatternSamples.StructuralPatterns.Proxy
{
    public class Storage : IStorage
    {
        public Storage()
        {
            Console.WriteLine($"{this.GetType().Name} - sendo criado");
        }
        public string Name => throw new NotImplementedException();

        public void CloseFile(string key)
        {
            Console.WriteLine($"{this.GetType().Name} - Fecha o arquivo {key}");
        }

        public void DeleteFile(string key)
        {
            Console.WriteLine($"{this.GetType().Name} - Deleta o arquivo {key}");
        }

        public void GetFile(string key)
        {
            Console.WriteLine($"{this.GetType().Name} - Retorna o arquivo {key}");
        }
    }
}
