using System.Collections.Generic;

public class Solution
{
    public IList<int> PreorderTraversal(TreeNode root)
    {
        var traversal = new List<int>();
        if (root == null)
        {
            return traversal;
        }
        
        var stack = new Stack<TreeNode>();
        stack.Push(root);

        while (stack.Count > 0)
        {
            var currentNode = stack.Pop();
            
            traversal.Add(currentNode.val);
            
            if (currentNode.right != null)
            {
                stack.Push(currentNode.right);
            }

            if (currentNode.left != null)
            {
                stack.Push(currentNode.left);
            }
        }

        return traversal;
    }
}