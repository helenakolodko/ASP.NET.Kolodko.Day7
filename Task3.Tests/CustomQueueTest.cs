using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3.Library;
using System.Collections;

namespace Task3.Tests
{
    [TestClass]
    public class CustomQueueTest
    {
        [TestMethod]
        public void Enqueue_Int_AddsToQueue()
        {
            CustomQueue<int> queue = new CustomQueue<int>();
            queue.Enqueue(5);

            Assert.AreEqual(5, queue.Peek());
        }

        [TestMethod]
        public void Peek_FromThreeIntQueue_ReturnsFirstOne()
        {
            CustomQueue<int> queue = new CustomQueue<int>();
            queue.Enqueue(5);
            queue.Enqueue(6);
            queue.Enqueue(11);

            Assert.AreEqual(5, queue.Peek());
        }

        [TestMethod]
        public void Peek_SecondTime_ReturnsFirstElementFromBegining()
        {
            CustomQueue<int> queue = new CustomQueue<int>( new int[]{5, 11, 6, 5, 9});
            queue.Peek();
   
            Assert.AreEqual(5, queue.Peek());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Peek_FromEmptyQueue_ThrowsException()
        {
            CustomQueue<int> queue = new CustomQueue<int>();
            queue.Peek();
        }

        [TestMethod]
        public void Dequeue_OneTime_ReturnsFirstElementFromBegining()
        {
            CustomQueue<int> queue = new CustomQueue<int>(new int[] { 5, 11, 6, 5, 9});

            Assert.AreEqual(5, queue.Dequeue());
        }

        [TestMethod]
        public void Dequeue_OneTime_DeletesFirstElementFromBegining()
        {
            CustomQueue<int> queue = new CustomQueue<int>(new int[] { 5, 11, 6, 5, 9, 5 });
            queue.Dequeue();

            Assert.AreEqual(11, queue.Peek());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Dequeue_FromEmptyQueue_ThrowsException()
        {
            CustomQueue<int> queue = new CustomQueue<int>();
            queue.Dequeue();
        }

        [TestMethod]
        public void Foreach_OnQueue_GetsItemsInRightOrder()
        {
            CustomQueue<int> queue = new CustomQueue<int>(new int[] { 5, 11, 6, 5, 9, 5 });
            int[] enumeration = new int[6];
            int i = 0;
            foreach (var item in queue)
            {
                enumeration[i++] = item;
            }

            Assert.IsTrue(((IStructuralEquatable)enumeration).Equals(new int[] { 5, 11, 6, 5, 9, 5 },
                 StructuralComparisons.StructuralEqualityComparer));
        }

        [TestMethod]
        public void Enqueue_TwentyElemets_ExpandsQueue()
        {
            CustomQueue<int> queue = new CustomQueue<int>();
            int[] expected = new int[20];
            for (int i = 0; i < 20; i++)
            {
                queue.Enqueue(i);
                expected[i] = i;
            }

            int[] enumeration = new int[20];
            int j = 0;
            foreach (var item in queue)
                enumeration[j++] = item;

            Assert.IsTrue(((IStructuralEquatable)enumeration).Equals(expected,
                 StructuralComparisons.StructuralEqualityComparer));
        }

        [TestMethod]
        public void Enqueue_SevenTimesAfterDequeueTenTimes_WorksRight()
        {
            CustomQueue<int> queue = new CustomQueue<int>();
            for (int i = 0; i < 10; i++)
                queue.Enqueue(i);
            for (int i = 0; i < 10; i++)
                queue.Dequeue();
            for (int i = 0; i < 7; i++)
                queue.Enqueue(i);

            int[] enumeration = new int[7];
            int j = 0;
            foreach (var item in queue)
            {
                enumeration[j++] = item;
            }

            Assert.IsTrue(((IStructuralEquatable)enumeration).Equals(new int[] { 0, 1, 2, 3, 4, 5, 6 },
                 StructuralComparisons.StructuralEqualityComparer));
        }

    }
}
