using System;
using System.Threading;
using NUnit.Framework;
using Solutions.Stuctures;

namespace Tests
{
    [TestFixture]
    public class DynamicArrayTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCreateDefault()
        {
            var dynamicArray = new DynamicArray<int>();
            Assert.AreEqual(0, dynamicArray.Count);
            Assert.AreEqual(10, dynamicArray.Capacity);
        }

        [Test]
        public void TestCreateWithConcreteCapacity()
        {
            var capacity = 20;
            var dynamicArray = new DynamicArray<int>(capacity);
            Assert.AreEqual(0, dynamicArray.Count);
            Assert.AreEqual(capacity, dynamicArray.Capacity);
        }

        [Test]
        public void TestAddWhenNotExceedCapacity()
        {
            var capacity = 2;
            var dynamicArray = new DynamicArray<int>(capacity);
            dynamicArray.Add(10);
            Assert.AreEqual(1, dynamicArray.Count);
            Assert.AreEqual(capacity, dynamicArray.Capacity);
        }

        [Test]
        public void TestAddWhenExceedsCapacity()
        {
            var capacity = 2;
            var dynamicArray = new DynamicArray<int>(capacity);
            dynamicArray.Add(10);
            dynamicArray.Add(20);
            dynamicArray.Add(30);

            Assert.AreEqual(3, dynamicArray.Count);
            Assert.AreEqual(capacity * 2, dynamicArray.Capacity);
        }

        [Test]
        public void TestFindExistingElement()
        {
            const int existingElement = 20;
            var dynamicArray = new DynamicArray<int>();
            dynamicArray.Add(10);
            dynamicArray.Add(20);
            dynamicArray.Add(30);

            Assert.IsTrue(dynamicArray.Exists(existingElement));
        }

        [Test]
        public void TestFindNotExistingElement()
        {
            const int notExistingElement = -20;
            var dynamicArray = new DynamicArray<int>();
            dynamicArray.Add(10);
            dynamicArray.Add(20);
            dynamicArray.Add(30);

            Assert.IsFalse(dynamicArray.Exists(notExistingElement));
        }

        [Test]
        public void TestRemoveExistingElement()
        {
            const int elementToRemove = 10;
            var dynamicArray = new DynamicArray<int>();
            dynamicArray.Add(10);
            dynamicArray.Add(20);
            dynamicArray.Add(30);

            Assert.AreEqual(3, dynamicArray.Count);
            Assert.IsTrue(dynamicArray.Exists(elementToRemove));

            dynamicArray.Remove(elementToRemove);

            Assert.AreEqual(2, dynamicArray.Count);
            Assert.IsFalse(dynamicArray.Exists(elementToRemove));
        }

        [Test]
        public void TestRemoveNotExistingElement()
        {
            const int elementToRemove = -10;
            var dynamicArray = new DynamicArray<int>();
            dynamicArray.Add(10);
            dynamicArray.Add(20);
            dynamicArray.Add(30);

            Assert.AreEqual(3, dynamicArray.Count);

            dynamicArray.Remove(elementToRemove);

            Assert.AreEqual(3, dynamicArray.Count);
        }

        [Test]
        public void TestClear()
        {
            const int capacity = 10;
            var dynamicArray = new DynamicArray<int>(capacity);
            dynamicArray.Add(10);
            dynamicArray.Add(20);
            dynamicArray.Add(30);

            Assert.AreEqual(3, dynamicArray.Count);
            Assert.AreEqual(capacity, dynamicArray.Capacity);

            dynamicArray.Clear();

            Assert.AreEqual(0, dynamicArray.Count);
            Assert.AreEqual(capacity, dynamicArray.Capacity);
        }

        [Test]
        public void TestAccessIndexThrowsArgumentOutOfRangeException()
        {
            var dynamicArray = new DynamicArray<int>();
            Assert.Throws<IndexOutOfRangeException>(() => dynamicArray[0] = 10);
        }

        [Test]
        public void TestAccessIndex()
        {
            const int newValue = 20;

            var dynamicArray = new DynamicArray<int>();
            dynamicArray.Add(10);
            dynamicArray[0] = newValue;

            Assert.AreEqual(newValue, dynamicArray[0]);
            Assert.AreEqual(1, dynamicArray.Count);
        }
    }

    public class Foo
    {
        private readonly EventWaitHandle waitFirst;
        private readonly EventWaitHandle waitSecond;

        public Foo()
        {
            waitFirst = new AutoResetEvent(false);
            waitSecond = new AutoResetEvent(false);
        }

        public void First(Action printFirst)
        {
            // printFirst() outputs "first". Do not change or remove this line.
            printFirst();

            waitFirst.Set();
        }

        public void Second(Action printSecond)
        {
            waitFirst.WaitOne();

            // printSecond() outputs "second". Do not change or remove this line.
            printSecond();

            waitSecond.Set();
        }

        public void Third(Action printThird)
        {
            waitSecond.WaitOne();

            // printThird() outputs "third". Do not change or remove this line.
            printThird();
        }
    }
}