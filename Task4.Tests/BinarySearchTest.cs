using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task4.Library;

namespace Task4.Tests
{
    [TestClass]
    public class BinarySearchTest
    {
        [TestMethod]
        public void BinarySearch_OnSortedIntArray_FindsPresentElement()
        {
            int[] array = { 1, 3, 5, 9, 11, 13, 54 };
            int index = array.BinarySearch(3, (a, b) => a.CompareTo(b));

            Assert.AreEqual(1, index);
        }

        [TestMethod]
        public void BinarySearch_OnSortedIntArray_DoesntFindNotPresentElement()
        {
            int[] array = { 1, 3, 5, 9, 11, 13, 54 };
            int index = array.BinarySearch(15, (a, b) => a.CompareTo(b));

            Assert.IsTrue(index < 0);
        }

        [TestMethod]
        public void BinarySearch_OnNonSortedIntArray_DoesntFindsPresentElement()
        {
            int[] array = { 1, 13, 5, 19, 11, 3, 54 };
            int index = array.BinarySearch(3, (a, b) => a.CompareTo(b));

            Assert.IsTrue(index < 0);
        }

        [TestMethod]
        public void BinarySearch_OnSortedStringArray_FindsPresentElement()
        {
            string[] array = { "a", "B", "cdfg", "day", "E", "e***", "geronimo" };
            int index = array.BinarySearch("E", (a, b) => string.Compare(a, b, true));

            Assert.AreEqual(4, index);
        }

        [TestMethod]
        public void BinarySearch_OnSortedStringArrayWithNull_FindsPresentElement()
        {
            string[] array = { "a", "B", null, "day", "E", "e***", "geronimo" };
            int index = array.BinarySearch("B", (a, b) => string.Compare(a, b, true));

            Assert.AreEqual(1, index);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void BinarySearch_OnNullArray_ThrowsException()
        {
            string[] array = null;
            int index = array.BinarySearch("B", (a, b) => string.Compare(a, b, true));
        }
    }
}
