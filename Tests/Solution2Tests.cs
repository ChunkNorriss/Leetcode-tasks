using NUnit.Framework;
using Solutions;
using Solutions.Stuctures;

namespace Tests
{
    [TestFixture]
    public class Solution2Tests
    {
        [SetUp]
        public void SetUp()
        {
            solution = new Solution2();
        }

        private Solution2 solution;

        [Test]
        public void Tests()
        {
            var l1 = new ListNode(2, new ListNode(4, new ListNode(3)));
            var l2 = new ListNode(5, new ListNode(6, new ListNode(4)));
            var result = solution.AddTwoNumbers(l1, l2);

            // Assert.AreEqual(expected, result);
        }
    }
}