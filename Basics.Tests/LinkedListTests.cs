using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Basics.Tests
{
    [TestFixture]
    public class LinkedListTests
    {
        private class StringList : LinkedList<string>
        {
            public string HeadValue => Head?.Value;
            public string FootValue => Foot?.Value;
        }

        [Test]
        public void ctor_HeadAndFootShouldBeNull()
        {
            var list = new StringList();

            Assert.Null(list.HeadValue);
            Assert.Null(list.FootValue);
        }

        [Test]
        public void Insert_InsertFirstValue_HeadAndFootAreSame()
        {
            var list = new StringList();
            list.Insert("hallo");

            Assert.AreSame(list.HeadValue, list.FootValue);
        }

        [Test]
        public void Insert_InsertOneValue_HeadAndFootShouldBeSetToThatValue()
        {
            var list = new StringList();
            list.Insert("hallo");

            Assert.AreEqual("hallo", list.HeadValue);
            Assert.AreEqual("hallo", list.FootValue);
        }

        [Test]
        [TestCase(new string[0], 0)]
        [TestCase(new[] { "one" }, 1)]
        [TestCase(new[] { "one", "two" }, 2)]
        public void Insert_InsertingValues_CountShouldBeUpdated(string[] values, int expectedCount)
        {
            var list = new StringList();
            foreach(var value in values)
            {
                list.Insert(value);
            }

            Assert.AreEqual(expectedCount, list.Count);
        }

        [Test]
        public void Enumerate_FilledList_ShouldIterateThroughAllValues()
        {
            var list = new StringList();
            list.Insert("a");
            list.Insert("b");
            list.Insert("c");

            var inserted = new List<string>();
            foreach(var value in list)
            {
                inserted.Add(value);
            }

            CollectionAssert.AreEqual(new[] { "a", "b", "c" }, inserted);
        }

        [Test]
        public void InsertAfter_InsertingInTheMiddle_InsertsElementAtTheCorrectSpot()
        {
            var list = new StringList();
            list.Insert("a");
            list.Insert("b");
            list.InsertAfter("a", "z");

            Assert.AreEqual("z", list.Skip(1).First());
        }

        [Test]
        public void InsertAfter_InsertingAtTheEnd_ShouldMakeValueLastElement()
        {
            var list = new StringList();
            list.Insert("a");
            list.InsertAfter("a", "b");

            Assert.AreEqual("b", list.Last());
        }

        [Test]
        public void InsertAfter_InsertingAfterNotExistingElement_ShouldThrowValueNotFoundException()
        {
            var list = new StringList();
            list.Insert("a");
            var ex = Assert.Throws<ValueNotFoundException>(() => list.InsertAfter("b", "c"));

            StringAssert.Contains(" b", ex.Message);
        }
    }
}
