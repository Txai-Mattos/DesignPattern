using System;

namespace CreationalPatterns.Singleton.Entitie
{
    //Singleton Class
    public class FileServer
    {
        //thread-safe by static prop
        private static readonly FileServer _intance = new FileServer();
        private FileServer()
        {
            Id = Guid.NewGuid();
            FullPath = @"c:\temp\temp.txt";
        }
        static FileServer() { }

        public Guid Id { get; set; }
        public string FullPath { get; set; }

        public void WriteFile() => Console.WriteLine($"Milliseconds:{DateTime.Now.Millisecond:000} - Id:{Id} - Caminho:{FullPath}");

        //Get Unique Instance of Singleton
        public static FileServer GetInstance()
            => _intance;

    }
}
