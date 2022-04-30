using System.Collections.Generic;
using NUnit.Framework;
using Solutions.AlgoExp;

namespace Tests;

[TestFixture]
public class ApartHuntingSolutionTests
{
    [Test]
    public void Test1()
    {
        var blocks = new List<Dictionary<string, bool>>
        {
            new()
            {
                { "gym", true },
                { "office", false },
                { "pool", false },
                { "school", true },
                { "store", false }
            },
            new()
            {
                { "gym", true },
                { "office", false },
                { "pool", false },
                { "school", true },
                { "store", false }
            },
            new()
            {
                { "gym", true },
                { "office", false },
                { "pool", false },
                { "school", true },
                { "store", false }
            },
            new()
            {
                { "gym", true },
                { "office", false },
                { "pool", false },
                { "school", true },
                { "store", false }
            },
            new()
            {
                { "gym", true },
                { "office", false },
                { "pool", false },
                { "school", true },
                { "store", false }
            },
            new()
            {
                { "gym", true },
                { "office", false },
                { "pool", false },
                { "school", true },
                { "store", false }
            }
        };
        var reqs = new[] { "gym", "school", "store" };
        var expected = 3;

        var idx = ApartHuntingSolution.ApartmentHunting(blocks, reqs);
        Assert.AreEqual(expected, idx);
    }
}