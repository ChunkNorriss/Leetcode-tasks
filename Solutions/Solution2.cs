using Solutions.Stuctures;

namespace Solutions
{
    public class Solution2
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var digit = 0;
            ListNode result = null;
            ListNode tailNode = null;
            var node1 = l1;
            var node2 = l2;
            while (node1 != null || node2 != null)
            {
                if (node1 != null)
                {
                    digit += node1.val;
                    node1 = node1.next;
                }

                if (node2 != null)
                {
                    digit += node2.val;
                    node2 = node2.next;
                }

                var newNode = new ListNode(digit % 10);
                if (result == null)
                    result = newNode;
                else
                    tailNode.next = newNode;

                tailNode = newNode;

                digit /= 10;
            }

            if (digit > 0) tailNode.next = new ListNode(digit);

            return result;
        }
    }
}