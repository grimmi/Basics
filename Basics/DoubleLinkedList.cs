using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Basics
{
    public class DoubleLinkedList<T> : IEnumerable<T> where T : IComparable<T>
    {
        protected DoubleLinkNode<T> Head { get; set; }
        protected DoubleLinkNode<T> Foot { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            var node = Head;
            while(node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        public void InsertAtEnd(T value)
        {
            if(Head == null)
            {
                Head = Foot = new DoubleLinkNode<T>(value);
                return;
            }

            Foot.Next = new DoubleLinkNode<T>(value);
            Foot = Foot.Next;
        }

        public void InsertInOrder(T value)
        {
            if(Head == null)
            {
                Head = Foot = new DoubleLinkNode<T>(value);
                return;
            }

            var node = Head;
            while(node != null && node.Value.CompareTo(value) < 0)
            {
                node = node.Next;
            }

            if(node == null)
            {
                InsertAtEnd(value);
                return;
            }

            var newNode = new DoubleLinkNode<T>(value);
            newNode.Previous = node.Previous;
            newNode.Next = node;
            if(node.Next != null)
            {
                node.Previous = newNode;
            }

            if(node == Head)
            {
                Head = newNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
