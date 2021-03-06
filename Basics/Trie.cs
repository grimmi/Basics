﻿using System;
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
            public Dictionary<string, TrieEdge> OutEdges { get; } = new Dictionary<string, TrieEdge>();

            public TrieNode(IEnumerable<TrieEdge> edges)
            {
                Value = string.Concat(edges.Select(e => e.Value));
                InEdge = edges.Any() ? edges.Last() : null;
            }

            public IEnumerable<TrieEdge> GetPath()
            {
                if(InEdge?.From != null)
                {
                    foreach(var edge in InEdge.From.GetPath())
                    {
                        yield return edge;
                    }
                    yield return InEdge;
                }
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

            var firstCharAsString = value[0].ToString();
            if (node.OutEdges.TryGetValue(firstCharAsString, out TrieEdge outEdge))
            {
                Insert(outEdge.To, value.Substring(1));
            }
            else
            {
                var newEdge = new TrieEdge(node, value.Substring(0, 1));
                node.OutEdges.Add(firstCharAsString, newEdge);
                Insert(newEdge.To, value.Substring(1));
            }
        }

        public bool Contains(string text)
        {
            if(string.IsNullOrWhiteSpace(text))
            {
                return true;
            }

            var node = Head;
            for(int i = 0; i < text.Length; i++)
            {
                if (node.OutEdges.TryGetValue(text[i].ToString(), out TrieEdge edge))
                {
                    node = edge.To;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
