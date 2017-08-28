using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Basics
{
    public class LinkedList<T> : IEnumerable<T>
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

        protected class LinkedEnumerator : IEnumerator<T>
        {
            private bool enumerationStarted = false;
            private Node<T> currentNode;
            public T Current => enumerationStarted
                ? currentNode.Value
                : throw new InvalidOperationException("enumeration not started!");

            object IEnumerator.Current => Current;


            private LinkedList<T> source;

            public LinkedEnumerator(LinkedList<T> list)
            {
                source = list;
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (!enumerationStarted)
                {
                    currentNode = source.Head;
                }
                else
                {
                    currentNode = currentNode.Next;
                }
                enumerationStarted = true;
                return currentNode != null;
            }

            public void Reset()
            {
                enumerationStarted = false;
                currentNode = null;
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

        public IEnumerator<T> GetEnumerator()
        {
            return new LinkedEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}