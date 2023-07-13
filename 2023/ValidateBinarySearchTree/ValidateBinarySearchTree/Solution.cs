public class Solution
{
    public bool IsValidBST(TreeNode root)
    {
        return IsInRange(root, long.MinValue, long.MaxValue);
    }

    private bool IsInRange(TreeNode node, long min, long max)
    {
        if (node == null)
        {
            return true;
        }

        return node.val > min && node.val < max && 
               IsInRange(node.left, min, node.val) &&
               IsInRange(node.right, node.val, max);
    }
}