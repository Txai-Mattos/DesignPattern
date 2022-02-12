using System.Collections.Generic;

namespace DesignPatternSamples.BehavioralPatterns.ChainOfResponsibility
{
    public class Context
    {
        public Context()
        {
            Started = new List<string>() { "Carlos", "Pedro", "Joao" };
            Middle = new List<string>();
            Finished = new List<string>();
        }
        public List<string> Started { get; set; }
        public List<string> Middle { get; set; }
        public List<string> Finished { get; set; }

        public override string ToString()
            => $"{nameof(Started)}: {string.Join(',', Started)} - {nameof(Middle)}: {string.Join(',', Middle)} - {nameof(Finished)}: {string.Join(',', Finished)}";

    }
}
