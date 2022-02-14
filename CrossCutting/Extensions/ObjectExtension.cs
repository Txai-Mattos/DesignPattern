using System;

namespace DesignPatternSamples.CrossCutting.Extensions
{
    public static class ObjectExtension
    {
        public static void Write(this object obj, string msg)
            => Console.WriteLine($"{obj.GetType().Name} - {msg}");
    }
}
