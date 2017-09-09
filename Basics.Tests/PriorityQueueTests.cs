using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basics.Tests
{
    [TestFixture]
    public class PriorityQueueTests
    {
        [Test]
        public void Peek_EmptyQueue_ThrowsException()
        {
            var queue = new PriorityQueue<int>((x, y) => x.CompareTo(y));
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => queue.Peek());
        }

        [Test]
        public void Pop_ItemsInsertedInRandomOrder_AreReturnedOrdered()
        {
            var queue = new PriorityQueue<int>(Comparer<int>.Default);
            queue.Insert(3);
            queue.Insert(2);
            queue.Insert(1);

            var x = queue.Pop();
            Assert.AreEqual(1, x);
            x = queue.Pop();
            Assert.AreEqual(2, x);
            x = queue.Pop();
            Assert.AreEqual(3, x);
        }
    }
}
