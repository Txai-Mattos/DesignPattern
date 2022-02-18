using System;

namespace DesignPatternSamples.CrossCutting.Extensions
{
    public static class ObjectExtension
    {
        public static void Write(this object obj, string msg, string predicate = "")
            => Console.WriteLine($"{predicate}{obj.GetType().Name} - {msg}");
    }
}
