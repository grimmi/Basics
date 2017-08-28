using System;
using System.Collections.Generic;
using System.Text;

namespace Basics
{
    public class LinkedList<T>
    {
        private class Node<T>
        {
            public T Value { get; }
            public Node<T> Next { get; set; }

            public Node(T value, Node<T> next)
            {
                Value = value;
                Next = next;
            }
        }

        private Node<T> Head { get; set; }
        private Node<T> Foot { get; set; }

        public LinkedList()
        {

        }

        public void Insert(T value)
        {
            if(Head == null)
            {
                Head = Foot = new Node<T>(value, null);
            }
            else
            {
                Foot.Next = new Node<T>(value, null);
                Foot = Foot.Next;
            }
        }

        private Node<T> GetFoot()
        {
            if(Head == null)
            {
                return null;
            }

            var node = Head;
            while(node.Next != null)
            {
                node = node.Next;
            }

            return node;
        }
    }