namespace Solutions
{
    public class Solution1721
    {
        public static ListNode SwapNodes(ListNode head, int k)
        {
            var leftNode = head;
            var rightNode = head;
            var tailNode = head;
            for (var i = 1; i < k; i++)
                leftNode = leftNode.next;

            tailNode = leftNode;
            while (tailNode.next != null)
            {
                tailNode = tailNode.next;
                rightNode = rightNode.next;
            }

            (leftNode.val, rightNode.val) = (rightNode.val, leftNode.val);

            return head;
        }

        public class ListNode
        {
            public ListNode next;
            public int val;

            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
    }
}