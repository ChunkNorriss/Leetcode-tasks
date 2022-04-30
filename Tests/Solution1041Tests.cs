using NUnit.Framework;
using Solutions;

namespace Tests
{
    [TestFixture]
    public class Solution1041Tests
    {
        [TestCase("GGLLGG", true)]
        [TestCase("GG", false)]
        [TestCase("GL", true)]
        [TestCase("LLGRL", true)]
        public void Tests(string instructions, bool expected)
        {
            var solution = new Solution1041();
            Assert.AreEqual(expected, solution.IsRobotBounded(instructions));
        }
    }
}