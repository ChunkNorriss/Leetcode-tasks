using System;
using NUnit.Framework;
using Solutions;

namespace Tests
{
    [TestFixture]
    public class Solution1721Tests
    {
        [Test]
        public void Tests()
        {
            var list = new Solution1721.ListNode(1);
            list.next = new Solution1721.ListNode(2);
            list.next.next = new Solution1721.ListNode(3);
            list.next.next.next = new Solution1721.ListNode(4);
            list.next.next.next.next = new Solution1721.ListNode(5);

            var swapNodes = Solution1721.SwapNodes(list, 2);

            while (swapNodes != null)
            {
                Console.WriteLine(swapNodes.val);
                swapNodes = swapNodes.next;
            }
        }
    }
}