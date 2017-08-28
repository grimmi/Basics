using NUnit.Framework;

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
    }
}
