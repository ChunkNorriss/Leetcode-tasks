using System.Collections.Generic;
using NUnit.Framework;
using Solutions.AlgoExpert;

namespace Tests.AlgoExpert
{
    [TestFixture]
    public class SolutionMoveElementToEndTests
    {
        [Test]
        [TestCase(new[] { 2, 1, 2, 2, 2, 3, 4, 2 }, 2, new[] { 1, 3, 4, 2, 2, 2, 2, 2 })]
        public void Tests(int[] array, int toMove, int[] expected)
        {
            var list = new List<int>(array);
            var actualList = SolutionMoveElementToEnd.MoveElementToEnd(list, toMove);

            Assert.AreEqual(new List<int>(expected), actualList);
        }
    }
}