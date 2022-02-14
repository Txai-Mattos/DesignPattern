using DesignPatternSamples.CrossCutting.Extensions;
using System.Collections.Generic;

namespace DesignPatternSamples.BehavioralPatterns.Iterator.Iterators
{
    public class ImparIterator<T> : IIterator where T : class
    {
        public ImparIterator(List<T> colletion)
        {
            Colletion = colletion;
            Index = 0;
        }
        private List<T> Colletion { get; }
        private int Index { get; set; }
        public bool IsDone()
        {
            if ((IsImparColletion ? Colletion.Count - 1 : Colletion.Count - 2) <= Index)
            {
                this.Write("Finalizado percursso na lista");
                return true;
            }
            return false;
        }

        public object CurrentItem => Colletion[Index];
        private bool IsImparColletion => Colletion.Count % 2 != 0;
        public object First()
        {
            if (IsDone())
                return 0;

            Index = 0;
            this.Write($"Metodo {nameof(First)} retornado o primeiro item impar da lista ( {Colletion[Index]} ) indice: {Index + 1}");
            return Colletion[Index];
        }

        public object Next()
        {
            if (IsDone())
                return 0;

            Index += 2;
            this.Write($"Metodo {nameof(Next)} retornado o proximo item impar da lista ( {Colletion[Index]} ) indice: {Index + 1}");
            return Colletion[Index];
        }
    }
}
