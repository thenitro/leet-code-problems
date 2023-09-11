using System.Collections.Generic;

public class Solution
{
    public IList<int> PostorderTraversal(TreeNode root)
    {
        var result = new List<int>();
        if (root == null)
        {
            return result;
        }
        
        var queue = new Stack<TreeNode>();
        queue.Push(root);

        while (queue.Count > 0)
        {
            var node = queue.Pop();
            result.Add(node.val);
            
            if (node.left != null) queue.Push(node.left);
            if (node.right != null) queue.Push(node.right);
        }

        result.Reverse();
        
        return result;
    }
}

