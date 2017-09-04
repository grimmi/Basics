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
            Assert.AreEqual("a", trie.HeadNode.OutEdges.First().Value.Value);
        }

        [Test]
        public void Insert_OneStringWithTwoLetters_TrieContainsOnePathWithThreeNodes()
        {
            var trie = new TestTrie();
            trie.Insert("ab");

            Assert.AreEqual(1, trie.HeadNode.OutEdges.Count);
            Assert.NotNull(trie.HeadNode.OutEdges["a"]);

            var aNode = trie.HeadNode.OutEdges["a"].To;
            Assert.NotNull(aNode);
            Assert.AreEqual("a", aNode.Value);
            Assert.AreEqual(1, aNode.OutEdges.Count);
            Assert.NotNull(aNode.OutEdges["b"]);

            var bNode = aNode.OutEdges["b"].To;
            Assert.NotNull(bNode);
            Assert.AreEqual("ab", bNode.Value);
        }

        [Test]
        public void Insert_TwoDifferentStrings_ShouldMakeTwoEdges()
        {
            var trie = new TestTrie();
            trie.Insert("a");
            trie.Insert("b");

            Assert.AreEqual(2, trie.HeadNode.OutEdges.Count);
            CollectionAssert.AreEquivalent(new[] { "a", "b" }, trie.HeadNode.OutEdges.Select(e => e.Value.Value));
        }


        [TestCase("test", "test", true)]
        [TestCase("test", "tes", true)]
        [TestCase("test", "te", true)]
        [TestCase("test", "t", true)]
        [TestCase("test", "", true)]
        [TestCase("test", "hello", false)]
        [TestCase("test", "est", false)]
        public void Contains_StringInput_ShouldReturnCorrectResult(string seed, string search, bool expected)
        {
            var trie = new Trie();
            trie.Insert(seed);

            Assert.AreEqual(expected, trie.Contains(search));
        }

        [Test]
        public void Contains_EmptyTrie_ShouldReturnFalse()
        {
            var trie = new Trie();

            Assert.False(trie.Contains("test"));
        }
    }
}
