using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Basics
{
    public class Queue<T> : IEnumerable<T>
    {
        private T[] array;
        private int head = -1;
        private int count = 0;

        public int Count => count;

        protected enum ResizeMode
        {
            Larger,
            Smaller
        }

        public Queue(int capacity = 4)
        {
            array = new T[capacity];
        }

        public void Enqueue(T value)
        {
            if(head == -1)
            {
                head = 0;
            }
            if(count == array.Length)
            {
                Resize(ResizeMode.Larger);
            }
            array[count++] = value;
        }

        protected virtual void Resize(ResizeMode mode)
        {
            if(mode == ResizeMode.Larger)
            {
                ResizeLarge();
            }
            else
            {
                ResizeSmall();
            }
        }

        protected virtual void ResizeLarge()
        {
            var tmpArray = new T[array.Length * 2];
            Array.Copy(array, tmpArray, array.Length);
            array = tmpArray;
        }

        protected virtual void ResizeSmall() { }

        public T Dequeue()
        {
            if(head == -1)
            {
                throw new QueueEmptyException();
            }

            return array[head++];            
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i < count; i++)
            {
                yield return Dequeue();
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
