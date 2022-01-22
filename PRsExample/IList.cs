using System;
using System.Collections.Generic;
using System.Text;

namespace PRsExample
{
    public interface IList<T>
    {
        void Add(T element);
        void AddFront(T element);
        void AddByIndex(int index, T element);
    }
}
