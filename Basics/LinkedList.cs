using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Basics
{
    public partial class LinkedList<T> : IEnumerable<T>
    {
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

            public void Dispose() { }

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

        public virtual void InsertAfter(T after, T value)
        {
            var node = GetNode(after);
            var newNode = new Node<T>(value, node.Next);
            node.Next = newNode;
        }

        protected virtual Node<T> GetNode(T value)
        {
            var node = Head;
            while(node != null && !node.Value.Equals(value))
            {
                node = node.Next;
            }
            return node ?? throw new ValueNotFoundException(value);
        }

        public IEnumerator<T> GetEnumerator() => new LinkedEnumerator(this);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}