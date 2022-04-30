using NUnit.Framework;
using Solutions;

namespace Tests
{
    [TestFixture]
    public class Solution1046Tests
    {
        [SetUp]
        public void SetUp()
        {
            solution = new Solution1046();
        }

        private Solution1046 solution;

        [Test]
        [TestCase(new[] { 1 }, 1)]
        [TestCase(new[] { 3, 1 }, 2)]
        [TestCase(new[] { 1, 3 }, 2)]
        [TestCase(new[] { 2, 7, 4, 1, 8, 1 }, 1)]
        public void Tests(int[] stones, int expected)
        {
            var actual = solution.LastStoneWeight(stones);
            Assert.AreEqual(expected, actual);
        }
    }
}