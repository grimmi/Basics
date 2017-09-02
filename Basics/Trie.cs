using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basics
{
    public class Trie
    {
        public class TrieEdge
        {
            public TrieNode From { get; }
            public TrieNode To { get; }

            public string Value { get; }
            public TrieEdge(TrieNode from, string value)
            {
                Value = value;
                From = from;
                To = new TrieNode(From.GetPath().Concat(new[] { this }));
            }
        }

        public class TrieNode
        {
            public string Value { get; }
            public TrieEdge InEdge { get; }
            public List<TrieEdge> OutEdges { get; } = new List<TrieEdge>();

            public TrieNode(IEnumerable<TrieEdge> edges)
            {
                Value = string.Concat(edges.Select(e => e.Value));
                InEdge = edges.Any() ? edges.Last() : null;
            }

            public IEnumerable<TrieEdge> GetPath()
            {
                var edge = InEdge;
                var path = new List<TrieEdge>();
                while(edge?.From != null)
                {
                    path.Add(edge);
                    edge = edge.From.InEdge;
                }

                return path.AsEnumerable().Reverse();
            }
        }

        protected TrieNode Head = new TrieNode(Enumerable.Empty<TrieEdge>());

        public Trie()
        {

        }

        public Trie(IEnumerable<string> values)
        {
            foreach(var value in values)
            {
                Insert(Head, value);
            }
        }

        public void Insert(string value)
        {
            Insert(Head, value);
        }

        protected virtual void Insert(TrieNode node, string value)
        {
            if (string.IsNullOrEmpty(value)) return;

            if(node.OutEdges.Any(e => value.StartsWith(e.Value)))
            {
                Insert(node.OutEdges.First(e => value.StartsWith(e.Value)).To, value.Substring(1));
            }
            else
            {
                var newEdge = new TrieEdge(node, value.Substring(0, 1));
                node.OutEdges.Add(newEdge);
                Insert(newEdge.To, value.Substring(1));
            }
        }
    }
}
