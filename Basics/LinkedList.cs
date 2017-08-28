using System;
using System.Collections.Generic;
using System.Text;

namespace Basics
{
    public class LinkedList<T>
    {
        protected class Node<TValue>
        {
            public TValue Value { get; }
            public Node<TValue> Next { get; set; }

            public Node(TValue value, Node<TValue> next)
            {
                Value = value;
                Next = next;
            }
        }

        protected Node<T> Head { get; set; }
        protected Node<T> Foot { get; set; }

        public int Count { get; private set; } = 0;

        public LinkedList()
        {

        }

        public virtual void Insert(T value)
        {
            if (Head == null)
            {
                Head = Foot = new Node<T>(value, null);
            }
            else
            {
                Foot.Next = new Node<T>(value, null);
                Foot = Foot.Next;
            }
            Count = Count + 1;
        }
    }
}