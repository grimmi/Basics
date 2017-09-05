using System;

namespace Basics
{
    public class Node<TValue> : IEquatable<Node<TValue>>
    {
        public TValue Value { get; }
        public Node<TValue> Next { get; set; }

        public Node(TValue value, Node<TValue> next)
        {
            Value = value;
            Next = next;
        }

        public bool Equals(Node<TValue> other)
        {
            return Value.Equals(other.Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }

    public class DoubleLinkNode<TValue> : IEquatable<DoubleLinkNode<TValue>>
    {
        public TValue Value { get; }
        public DoubleLinkNode<TValue> Previous { get; set; }
        public DoubleLinkNode<TValue> Next { get; set; }

        public DoubleLinkNode(TValue value)
        {
            Value = value;
        }

        public bool Equals(DoubleLinkNode<TValue> other)
        {
            return Value.Equals(other.Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
