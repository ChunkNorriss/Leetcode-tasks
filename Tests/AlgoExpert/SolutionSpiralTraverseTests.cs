using NUnit.Framework;
using Solutions.AlgoExpert;

namespace Tests.AlgoExpert
{
    [TestFixture]
    public class SolutionSpiralTraverseTests
    {
        [Test]
        // [TestCase(new int [,] {{1, 2, 3, 4}} , new[] { 1, 4, 9, 25, 36, 64, 81 })]
        public void Tests()
        {
            var array = new int[3, 4];
            array[0, 0] = 1;
            array[0, 1] = 2;
            array[0, 2] = 3;
            array[0, 3] = 4;

            array[1, 0] = 10;
            array[1, 1] = 11;
            array[1, 2] = 12;
            array[1, 3] = 5;

            array[2, 0] = 9;
            array[2, 1] = 8;
            array[2, 2] = 7;
            array[2, 3] = 6;

            var actual = SolutionSpiralTraverse.SpiralTraverse(array);
        }
    }
}