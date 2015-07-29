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
        private int count;
        private int capacity = 16;

        public CustomQueue(IEnumerable<T> collection)
            : base(collection.ToArray())
        { }

        public CustomQueue(T[] collection) : 
            base(collection.Length)
        { 
            count = capacity;
            Array.Copy(collection, items, capacity);
        }

        public CustomQueue(int capacity)
        {
            this.capacity = capacity;
            items = new T[capacity];
        }
        public void Enqueue(T item)
        {
            if (count >= capacity)
            {
                ExpandItemsArray();
            }
            items[count] = item;
            count++;
        }

        public T Dequeue()
        {
            T result = Peek();
            count--;
            items[count] = default(T);
            return result;
        }

        public T Peek()
        {
            if (count <= 0)
            {
                throw new InvalidOperationException("The Queue is empty.");
            }
            return items[count - 1];
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
            capacity *= 2;
            T[] temp = new T[capacity];
            Array.Copy(items, temp, count);
        }

        private class Enumerator<T> : IEnumerator<T>
        {
            private CustomQueue<T> queue;
            private int currentIndex;
            internal Enumerator(CustomQueue<T> queue)
            {
                this.currentIndex = -1;
                this.queue = queue;
            }
            public T Current
            {
                get
                {
                    if (currentIndex < 0 || currentIndex >= queue.count)
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
                return ++currentIndex < queue.count;
            }

            public void Reset()
            {
                currentIndex = -1;
            }
        }
    }
}