using NUnit.Framework;
using System.Linq;

namespace Basics.Tests
{

    [TestFixture]
    public class DoubleLinkedListTests
    {
        [Test]
        public void InsertInOrder_ValidValues_ValuesAreInOrder()
        {
            var list = new DoubleLinkedList<int>();
            list.InsertInOrder(3);
            list.InsertInOrder(2);
            list.InsertInOrder(1);

            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, list.ToArray());
        }

        [Test]
        public void InsertInOrder_InsertElements_AllElementsShouldBeInList()
        {
            var list = new DoubleLinkedList<int>();
            list.InsertInOrder(1);
            list.InsertInOrder(2);
            list.InsertInOrder(3);

            Assert.AreEqual(3, list.Count());
        }

        [Test]
        public void InsertInOrder_SameElementTwice_ShouldReturnBoth()
        {
            var list = new DoubleLinkedList<int>();
            list.InsertInOrder(2);
            list.InsertInOrder(2);

            Assert.AreEqual(2, list.Count());
            CollectionAssert.AreEqual(new[] { 2, 2 }, list.ToArray());
        }
    }
}
