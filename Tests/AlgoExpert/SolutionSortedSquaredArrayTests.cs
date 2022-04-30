using NUnit.Framework;
using Solutions.AlgoExpert;

namespace Tests.AlgoExpert
{
    [TestFixture]
    public class SolutionSortedSquaredArrayTests
    {
        [Test]
        [TestCase(new[] { 1, 2, 3, 5, 6, 8, 9 }, new[] { 1, 4, 9, 25, 36, 64, 81 })]
        public void Tests(int[] array, int[] expected)
        {
            var actual = new SolutionSortedSquaredArray().SortedSquaredArray(array);

            Assert.AreEqual(expected, actual);
        }
    }
}