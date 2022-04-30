using Solutions.Stuctures;

namespace Solutions
{
    public class Solution99
    {
        public void RecoverTree(TreeNode root)
        {
            RecoverTree(root, null, null);
        }

        private void RecoverTree(TreeNode node, TreeNode minNode, TreeNode maxNode)
        {
            if (node == null)
                return;

            if (node.val < minNode?.val)
            {
                Swap(node, minNode);
                return;
            }

            if (node.val > maxNode?.val)
            {
                Swap(node, maxNode);
                return;
            }

            RecoverTree(node.left, minNode, node);
            RecoverTree(node.right, node, maxNode);
        }

        private static void Swap(TreeNode node1, TreeNode node2)
        {
            (node1.val, node2.val) = (node2.val, node1.val);
        }
    }
}
