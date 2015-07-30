using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Library
{
    public class CustomQueue<T>: IEnumerable<T>
    {
        private T[] items;
        private int start;
        private int count;
        private int capacity;

        public CustomQueue(IEnumerable<T> collection)
            : this(collection.ToArray())
        { }

        public CustomQueue(T[] collection) : 
            this(collection.Length)
        { 
            count = capacity;
            Array.Copy(collection, items, capacity);
        }

        public CustomQueue()
            : this(16)
        { }

        public CustomQueue(int capacity)
        {
            this.capacity = capacity;
            items = new T[capacity];
        }
        public void Enqueue(T item)
        {
            if (count + start >= capacity)
            {
                ExpandItemsArray();
            }
            items[start + count] = item;
            count++;
        }

        public T Dequeue()
        {
            T result = Peek();
            items[start] = default(T);
            start++; count--; 
            return result;
        }

        public T Peek()
        {
            if (count <= 0)
            {
                throw new InvalidOperationException("The Queue is empty.");
            }
            return items[start];
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator<T>(this);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new Enumerator<T>(this);
        }
        
        private void ExpandItemsArray()
        {
            if (start < count || count >= capacity)
                capacity *= 2;
            T[] temp = new T[capacity];
            Array.Copy(items, start, temp, 0, count);
            items = temp;
            start = 0;
        }

        private class Enumerator<T> : IEnumerator<T>
        {
            private CustomQueue<T> queue;
            private int currentIndex;
            internal Enumerator(CustomQueue<T> queue)
            {
                this.currentIndex = queue.start - 1;
                this.queue = queue;
            }
            public T Current
            {
                get
                {
                    if (currentIndex < queue.start || currentIndex >= queue.capacity)
                    {
                        throw new InvalidOperationException();
                    }
                    return queue.items[currentIndex];
                }
            }

            public void Dispose()
            { }

            object System.Collections.IEnumerator.Current
            {
                get { throw new NotImplementedException(); }
            }

            public bool MoveNext()
            {
                currentIndex++;
                return currentIndex - queue.start < queue.count;
            }

            public void Reset()
            {
                currentIndex = queue.start - 1;
            }
        }
    }
}