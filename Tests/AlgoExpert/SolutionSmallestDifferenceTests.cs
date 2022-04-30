using NUnit.Framework;
using Solutions.AlgoExpert;

namespace Tests.AlgoExpert
{
    [TestFixture]
    public class SolutionSmallestDifferenceTests
    {
        [Test]
        [TestCase(new[] { -1, 5, 10, 20, 28, 3 }, new[] { 26, 134, 135, 15, 17 }, new[] { 28, 26 })]
        public void Tests(int[] arrayOne, int[] arrayTwo, int[] expected)
        {
            var medianSortedArrays = SolutionSmallestDifference.SmallestDifference(arrayOne, arrayTwo);

            Assert.AreEqual(expected, medianSortedArrays);
        }
    }
}