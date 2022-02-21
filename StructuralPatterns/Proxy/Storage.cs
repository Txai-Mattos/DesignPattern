using DesignPatternSamples.CrossCutting.Extensions;
using System;

namespace DesignPatternSamples.StructuralPatterns.Proxy
{
    public class Storage : IStorage
    {
        public Storage()
        {
            this.Write("sendo criado");
        }
        public string Name => throw new NotImplementedException();

        public void CloseFile(string key)
        {
            this.Write($"Fecha o arquivo {key}");
        }

        public void DeleteFile(string key)
        {
            this.Write($"Deleta o arquivo {key}");
        }

        public void GetFile(string key)
        {
            this.Write($"Retorna o arquivo {key}");
        }
    }
}
