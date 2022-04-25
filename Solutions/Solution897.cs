using Solutions.DataStructures;

namespace Solutions;

public class Solution897
{
    public TreeNode IncreasingBST(TreeNode root)
    {
        var newRoot = new TreeNode();
        Inorder(newRoot, root);
        return newRoot.right;
    }

    private static TreeNode Inorder(TreeNode root, TreeNode node)
    {
        if (node == null)
            return root;
        
        if (node.left != null)
        {
            root = Inorder(root, node.left);
            node.left = null;
        }

        root.right = node;

        return Inorder(root.right, node.right);
    }
}
