using System;

namespace DesignPatternSamples.CrossCutting
{
    public static class Execute
    {
        public static void Register(bool start, string method)
        {
            var prefix = start ? "Inicio" : "Fim";
            Console.WriteLine($"\n{prefix} - {method}\n");
        }
    }
}
