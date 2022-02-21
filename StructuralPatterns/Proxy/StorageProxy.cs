using DesignPatternSamples.CrossCutting.Extensions;
using System.Collections.Generic;

namespace DesignPatternSamples.StructuralPatterns.Proxy
{
    //Proxy
    public class StorageProxy : IStorage
    {
        //Referencia ao objeto real
        private IStorage _storage;
        //propriedade extra para controle de dados
        private readonly Dictionary<string, bool> _filesOpened = new();

        //Realizando processamento antes  depois de chamar a requisição no objeto real, log, lazy initializa
        public void GetFile(string key)
        {
            WriteLog($"Iniciando processo para obtenção do arquivo {key}");
            GetRealSubject().GetFile(key);

            SetFileStatus(key, true);

            WriteLog($"Finalizada processo para obtenção do arquivo {key}");
        }

        //Realizando processamento antes  depois de chamar a requisição no objeto real, log, lazy initializa
        public void CloseFile(string key)
        {
            WriteLog($"Iniciando fechamento do arquivo {key}");
            GetRealSubject().CloseFile(key);

            SetFileStatus(key, false);

            WriteLog($"Finalizado fechamento do arquivo {key}");
        }
        //Realizando processamento antes  depois de chamar a requisição no objeto real, log, lazy initializae, checkagem de bloqueio
        public void DeleteFile(string key)
        {
            WriteLog($"Iniciando deleção do arquivo {key}");
            if (_filesOpened.TryGetValue(key, out bool opened) && opened)
            {
                WriteLog($"Não é possível deletar o arquivo {key} pois ele está aberto!");
                return;
            }

            GetRealSubject().DeleteFile(key);

            WriteLog($"fim da deleção do arquivo {key}");
        }

        private void WriteLog(string message)
        {
            this.Write($"{message}");
        }

        //lazy initializa
        private IStorage GetRealSubject()
        {
            WriteLog($"Gerindo a obtenção da instância do {nameof(Storage)} inicialização atrasada - modelo simplificado não é threadSafe");
            if (_storage == default)
                _storage = new Storage();
            return _storage;
        }

        private void SetFileStatus(string key, bool opened)
        {
            if (!_filesOpened.ContainsKey(key))
                _filesOpened.Add(key, opened);
            else
                _filesOpened[key] = opened;
        }

    }
}
