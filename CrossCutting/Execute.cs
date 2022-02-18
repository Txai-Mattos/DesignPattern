using System;

namespace DesignPatternSamples.CrossCutting
{
    public static class Execute
    {
        public static void Run(Action method)
        {
            Register(true, method.Method.Name);
            method.Invoke();
            Register(false, method.Method.Name);
        }
        private static void Register(bool start, string method)
        {
            var prefix = start ? "Inicio" : "Fim";
            Console.WriteLine($"\n{prefix} - {method}\n");
        }
    }
}
