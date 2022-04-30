using System.Collections.Generic;
using NUnit.Framework;
using Solutions.AlgoExpert;

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
                { "gym", false },
                { "office", false },
                { "pool", false },
                { "school", false },
                { "store", false }
            },
            new()
            {
                { "gym", false },
                { "office", true },
                { "pool", false },
                { "school", true },
                { "store", false }
            },
            new()
            {
                { "gym", false },
                { "office", true },
                { "pool", false },
                { "school", false },
                { "store", false }
            },
            new()
            {
                { "gym", false },
                { "office", false },
                { "pool", false },
                { "school", false },
                { "store", true }
            },
            new()
            {
                { "gym", true },
                { "office", true },
                { "pool", false },
                { "school", false },
                { "store", false }
            },
            new()
            {
                { "gym", false },
                { "office", false },
                { "pool", true },
                { "school", false },
                { "store", false }
            },
            new()
            {
                { "gym", false },
                { "office", false },
                { "pool", false },
                { "school", false },
                { "store", false }
            },
            new()
            {
                { "gym", false },
                { "office", false },
                { "pool", false },
                { "school", false },
                { "store", false }
            },
            new()
            {
                { "gym", false },
                { "office", false },
                { "pool", false },
                { "school", true },
                { "store", false }
            },
            new()
            {
                { "gym", false },
                { "office", false },
                { "pool", true },
                { "school", false },
                { "store", false }
            }
        };
        var reqs = new[] { "gym", "pool", "school", "store" };
        var expected = 4;

        var idx = ApartHuntingSolution.ApartmentHunting(blocks, reqs);
        Assert.AreEqual(expected, idx);
    }
}