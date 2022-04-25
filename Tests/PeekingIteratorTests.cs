using System.Collections.Generic;
using NUnit.Framework;
using Solutions;

namespace Tests;

[TestFixture]
public class PeekingIteratorTests
{
    [Test]
    public void Test()
    {
        var list = new List<int>(new[] { 1, 2, 3 });
        var peekingIterator = new PeekingIterator(list.GetEnumerator());
        var enumerator = new int[]{1, 2, 3}.GetEnumerator();
        
        
        //"next", "peek", "next", "next", "hasNext"
        
        Assert.AreEqual(1, peekingIterator.Next());
        Assert.AreEqual(2, peekingIterator.Peek());
        Assert.AreEqual(2, peekingIterator.Next());
        Assert.AreEqual(3, peekingIterator.Next());
        Assert.AreEqual(false, peekingIterator.HasNext());
    }
}