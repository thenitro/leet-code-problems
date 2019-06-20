namespace InvertBinaryTree
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var root = new TreeNode(4)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(1),
                    right = new TreeNode(3),
                },
                right = new TreeNode(2)
                {
                    left = new TreeNode(6),
                    right = new TreeNode(9),
                }
            };

            new Solution().InvertTree(root);
        }
    }
}

public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}

public class Solution {
    public TreeNode InvertTree(TreeNode root)
    {
        Invert(root);
        return root;
    }

    private void Invert(TreeNode node)
    {
        if (node == null)
        {
            return;
        }

        var temp = node.left;
        node.left = node.right;
        node.right = temp;
        
        Invert(node.left);
        Invert(node.right);
    }
}