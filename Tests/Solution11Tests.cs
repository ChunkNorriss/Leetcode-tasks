using NUnit.Framework;
using Solutions;

namespace Tests
{
    [TestFixture]
    public class Solution11Tests
    {
        [SetUp]
        public void SetUp()
        {
            solution = new Solution11();
        }

        private Solution11 solution;

        [Test]
        [TestCase(new[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }, 49)]
        [TestCase(new[] { 1, 2, 4, 3 }, 4)]
        [TestCase(new[] { 1, 3, 2, 5, 25, 24, 5 }, 24)]
        public void Tests(int[] height, int expected)
        {
            var maxArea = solution.MaxArea(height);

            Assert.AreEqual(expected, maxArea);
        }
    }
}