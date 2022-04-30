using NUnit.Framework;
using Solutions;

namespace Tests
{
    [TestFixture]
    public class Solution4Tests
    {
        [SetUp]
        public void SetUp()
        {
            solution4 = new Solution4();
        }

        private Solution4 solution4;

        [Test]
        [TestCase(new[] { 1, 3 }, new[] { 2 }, 2.0)]
        [TestCase(new[] { 1, 2 }, new[] { 3, 4 }, 2.5)]
        [TestCase(new[] { 1, 3 }, new[] { 2, 7 }, 2.5)]
        [TestCase(new[] { 1 }, new[] { 2, 3, 4 }, 2.5)]
        public void Tests(int[] nums1, int[] nums2, double expected)
        {
            var medianSortedArrays = solution4.FindMedianSortedArrays(nums1, nums2);

            Assert.AreEqual(expected, medianSortedArrays);
        }
    }
}