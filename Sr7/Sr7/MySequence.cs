using System.Collections.Generic;

namespace Sr7
{
    public class MySequence<T> : ILocalMinimum<T> where T : class
    {
        private List<T> seq;
        public T this[int idx] { get => seq[idx]; set => seq[idx] = value; }
    }
}