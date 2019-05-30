using System;

namespace ConvertSortedArrayToBinarySearchTree
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(PrintNode(new Solution().SortedArrayToBST(new int[] {-10, -3, 0, 5, 9})));
            Console.WriteLine(PrintNode(new Solution().SortedArrayToBST(new int[] {-10, -3, 1, 3, 5, 9})));
            Console.WriteLine(PrintNode(new Solution().SortedArrayToBST(new int[] {})));
            Console.WriteLine(PrintNode(new Solution().SortedArrayToBST(new int[] { 1 })));
            Console.WriteLine(PrintNode(new Solution().SortedArrayToBST(new int[] { 1, 3 }))); 
            Console.WriteLine(PrintNode(new Solution().SortedArrayToBST(new int[] { 0, 1, 2, 3, 4, 5 })));
    }

        private static string PrintNode(TreeNode node, int tabs = 0)
        {
            var prefix = "\n|";

            for (int i = 0; i < tabs; i++)
            {
                prefix += "--";
            }
            
            if (node == null)
            {
                return prefix + "None";
            }

            tabs++;
            
            return prefix + "V: " + node.val + "" + PrintNode(node.left, tabs) + "" + PrintNode(node.right, tabs);
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
    public TreeNode SortedArrayToBST(int[] nums)
    {
        return Convert(nums, 0, nums.Length - 1);
    }

    private TreeNode Convert(int[] nums, int start, int end)
    {
        if (start > end)
        {
            return null;
        }
        
        var mid = (start + end) / 2;
        
        var node = new TreeNode(nums[mid]);
            node.left = Convert(nums, start, mid - 1);
            node.right = Convert(nums, mid + 1, end);

        return node;
    }
}