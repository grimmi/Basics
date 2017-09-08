using System;
using System.Collections.Generic;
using System.Text;

namespace Basics
{
    public class PriorityQueue<T>
    {
        private IComparer<T> comparer;
        private List<T> InternalList { get; } = new List<T>();

        private int listIndex;

        public PriorityQueue(Func<T, T, int> compare)
        {
            comparer = new DelegateComparer(compare);
        }

        public PriorityQueue(IComparer<T> comparer)
        {
            this.comparer = comparer;
        }

        public void Insert(T value)
        {
            InternalList.Add(value);
            InternalList.Sort(comparer);
            listIndex = 0;
        }

        public T Peek()
        {
            return InternalList[listIndex];
        }

        public T Pop()
        {
            return InternalList[listIndex++];
        }

        private class DelegateComparer : IComparer<T>
        {
            private Func<T, T, int> compareFunc;

            public int Compare(T x, T y) => compareFunc(x, y);

            public DelegateComparer(Func<T, T, int> compare)
            {
                compareFunc = compare;
            }
        }
    }
}
