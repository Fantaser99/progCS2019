using System;

namespace Sr7
{
    public interface ILocalMinimum<T> where T : IComparable<T>
    {
        T this[int idx] { get; set; }

        int CountLocalMinimum();

        bool IsAllEqual { get; set; }
    }
}