using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basics.Tests
{
    [TestFixture]
    public class QueueTests
    {
        private class TestQueue : Queue<string>
        {
            public int LargeResizes { get; set; } = 0;
            public int SmallResizes { get; set; } = 0;
            protected override void Resize(ResizeMode mode)
            {
                switch(mode)
                {
                    case Queue<string>.ResizeMode.Larger: LargeResizes++; break;
                    case Queue<string>.ResizeMode.Smaller: SmallResizes++; break;
                }
                base.Resize(mode);
            }

            public TestQueue(int capacity = 4) : base(capacity) { }
        }

        [Test]
        public void Enqueue_IntoEmptyQueue_QueueContainsOneItem()
        {
            var queue = new Queue<string>();
            queue.Enqueue("hallo");

            Assert.AreEqual(1, queue.Count);
        }

        [Test]
        public void Enqueue_EnqueueMoreItemsThanCapacity_ResizeLargeIsCalledOnce()
        {
            var queue = new TestQueue(2);
            queue.Enqueue("a");
            queue.Enqueue("b");
            Assert.AreEqual(0, queue.LargeResizes);
            queue.Enqueue("c");
            Assert.AreEqual(1, queue.LargeResizes);
        }
    }
}
