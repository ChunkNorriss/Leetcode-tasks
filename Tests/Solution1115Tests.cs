using System;
using System.Threading;
using NUnit.Framework;
using Solutions;

namespace Tests
{
    [TestFixture]
    public class Solution1115Tests
    {
        [Test]
        public void Tests()
        {
            var fooBar = new FooBar(10);
            var fooThread = new Thread(() => fooBar.Foo(() => Console.Write("foo")));
            var barThread = new Thread(() => fooBar.Bar(() => Console.WriteLine("bar")));

            barThread.Start();
            fooThread.Start();
        }
    }
}