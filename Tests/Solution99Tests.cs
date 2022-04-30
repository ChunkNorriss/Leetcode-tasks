using NUnit.Framework;
using Solutions;
using Solutions.Stuctures;

namespace Tests
{
    [TestFixture]
    public class Solution99Tests
    {
        [SetUp]
        public void SetUp()
        {
            solution = new Solution99();
        }

        private Solution99 solution;

        [Test]
        public void Test1()
        {
            var treeNode =
                new TreeNode(3,
                    new TreeNode(1),
                    new TreeNode(4,
                        new TreeNode(2)
                    )
                );
            solution.RecoverTree(treeNode);
        }

        [Test]
        public void Test2()
        {
            var treeNode =
                new TreeNode(1,
                    new TreeNode(3,
                        null,
                        new TreeNode(2))
                );
            solution.RecoverTree(treeNode);
        }

        [Test]
        public void Test3()
        {
            var treeNode =
                new TreeNode(2,
                    new TreeNode(3),
                    new TreeNode(2)
                );
            solution.RecoverTree(treeNode);
        }


        [Test]
        public void SmallestStringWithSwapsSolutionTests()
        {
            var s = "udyyek";
            // var pairs = new[]
            // {
            //     new[] { 3, 3 },
            //     new[] { 3, 0 },
            //     new[] { 5, 1 },
            //     new[] { 3, 1 },
            //     new[] { 3, 4 },
            //     new[] { 3, 5 },
            // };
            var pairs = new int[0][];

            var expected = "deykuy";
            
            var smallestStringWithSwapsSolution = new SmallestStringWithSwapsSolution();

            var actual = smallestStringWithSwapsSolution.SmallestStringWithSwaps(s, pairs);
            
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void MinimumEffortPathTests()
        {
            var pairs = new[]
            {
                new[] { 1, 2, 2 },
                new[] { 3, 8, 2 },
                new[] { 5, 3, 5 },
            };

            var pathSolution = new MinimumEffortPathSolution();
            var minimumEffortPath = pathSolution.MinimumEffortPath(pairs);
        }
    }
}