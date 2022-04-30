using NUnit.Framework;
using Solutions;

namespace Tests
{
    [TestFixture]
    public class Solution289Tests
    {
        [SetUp]
        public void Setup()
        {
            solution = new Solution289();
        }

        private Solution289 solution;

        [Test]
        public void Test2X2()
        {
            var board = new[]
            {
                new[] { 1, 1 },
                new[] { 1, 0 }
            };

            var expected = new[]
            {
                new[] { 1, 1 },
                new[] { 1, 1 }
            };

            solution.GameOfLife(board);

            Assert.AreEqual(expected, board);
        }

        [Test]
        public void Test4X3()
        {
            var board = new[]
            {
                new[] { 0, 1, 0 },
                new[] { 0, 0, 1 },
                new[] { 1, 1, 1 },
                new[] { 0, 0, 0 }
            };

            var expected = new[]
            {
                new[] { 0, 0, 0 },
                new[] { 1, 0, 1 },
                new[] { 0, 1, 1 },
                new[] { 0, 1, 0 }
            };

            solution.GameOfLife(board);

            Assert.AreEqual(expected, board);
        }
    }
}