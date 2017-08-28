using System;
using System.Collections.Generic;
using System.Text;

namespace Basics
{
    public class LinkedList<T>
    {
        protected class Node<T>
        {
            public T Value { get; }
            public Node<T> Next { get; set; }

            public Node(T value, Node<T> next)
            {
                Value = value;
                Next = next;
            }
        }

        protected Node<T> Head { get; set; }
        protected Node<T> Foot { get; set; }

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
        }
    }
}