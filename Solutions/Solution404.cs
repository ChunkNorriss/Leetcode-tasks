using System.Collections.Generic;
using Solutions.DataStructures;

namespace Solutions;

public class Solution404 {
    public int SumOfLeftLeaves(TreeNode root) {
        var sum = 0;
        while (root != null)
        {
            if (root.left != null)
            {
                var left = root.left;
                var isLeaf = left.left == null && left.right == null;

                if (isLeaf)
                    sum += left.val;
                else
                    sum += SumOfLeftLeaves(left);
            }

            root = root.right;
        }

        return sum;
    }
}

public class BSTIterator {
    private readonly Stack<TreeNode> pathToRoot = new();

    public BSTIterator(TreeNode root)
    {
        pathToRoot.Push(root);
    }
    
    public int Next()
    {
        var nextNode = GetNextNode();
        return nextNode.val;
    }

    private TreeNode GetNextNode()
    {
        while (HasNext())
        {
            var node = pathToRoot.Peek();
            if (node.left != null)
            {
                pathToRoot.Push(node.left);
                continue;
            }

            pathToRoot.Pop();
            if (node.right != null) 
                pathToRoot.Push(node.right);

            return node;
        }

        return null;
    }

    public bool HasNext() {
        return pathToRoot.Count > 0;
    }
}
