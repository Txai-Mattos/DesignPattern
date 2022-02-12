using System;

namespace DesignPatternSamples.CrossCutting.Extensions
{
    public static class ObjectExtension
    {
        public static void WriteIntoConsole(this object obj, string msg)
            => Console.WriteLine($"{obj.GetType().Name} - {msg}");
    }
}
