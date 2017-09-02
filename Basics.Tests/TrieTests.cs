using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basics.Tests
{
    [TestFixture]
    public class TrieTests
    {
        private class TestTrie : Trie
        {
            public TrieNode HeadNode => Head;
        }

        [Test]
        public void Insert_SingleLetter_TrieContainsOneEdgeAndTwoItems()
        {
            var trie = new TestTrie();
            trie.Insert("a");

            Assert.AreEqual(1, trie.HeadNode.OutEdges.Count);
            Assert.AreEqual("a", trie.HeadNode.OutEdges.First().Value);
        }

        [Test]
        public void Insert_OneStringWithTwoLetters_TrieContainsOnePathWithThreeNodes()
        {
            var trie = new TestTrie();
            trie.Insert("ab");

            Assert.AreEqual(1, trie.HeadNode.OutEdges.Count);
            Assert.AreEqual("a", trie.HeadNode.OutEdges.First().Value);

            var aNode = trie.HeadNode.OutEdges.First().To;
            Assert.NotNull(aNode);
            Assert.AreEqual("a", aNode.Value);
            Assert.AreEqual(1, aNode.OutEdges.Count);
            Assert.AreEqual("b", aNode.OutEdges.First().Value);

            var bNode = aNode.OutEdges.First().To;
            Assert.NotNull(bNode);
            Assert.AreEqual("ab", bNode.Value);
        }
    }
}
