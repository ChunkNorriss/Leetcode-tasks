using NUnit.Framework;
using Solutions;

namespace Tests;

[TestFixture]
public class Solution581Tests
{
    [SetUp]
    public void SetUp()
    {
        solution = new Solution581();
    }

    private Solution581 solution;

    [TestCase(new [] {2,6,4,8,10,9,15}, 5)]
    [TestCase(new [] {1,2,4,5,3}, 3)]
    [TestCase(new [] {1}, 0)]
    [TestCase(new [] {1, 2}, 0)]
    [TestCase(new [] {1,3,2,3,3}, 2)]
    [TestCase(new [] {2,1,5,3,4}, 5)]
    public void Tests(int[] nums, int expected)
    {
        var actual = solution.FindUnsortedSubarray(nums);
        Assert.AreEqual(expected, actual);
    }
}