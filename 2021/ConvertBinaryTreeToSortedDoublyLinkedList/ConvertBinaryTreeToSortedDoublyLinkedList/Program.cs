namespace ConvertBinaryTreeToSortedDoublyLinkedList
{
    internal class Program
    {
        public static void Main(string[] args)
        {
        }
    }
}

public class Solution
{
    public Node TreeToDoublyList(Node root)
    {
        if (root == null)
        {
            return root;
        }

        var head = new Node();
        var last = head;

        var node = root;
        while (node != null)
        {
            if (node.left != null)
            {
                var predecessor = node.left;

                while (predecessor.right != null && predecessor.right != node)
                {
                    predecessor = predecessor.right;
                }

                if (predecessor.right == null)
                {
                    predecessor.right = node;
                    node = node.left;
                }
                else
                {
                    last.right = node;
                    node.left = last;
                    last = node;
                    node = node.right;
                }
            }
            else
            {
                last.right = node;
                node.left = last;
                last = node;
                node = node.right;
            }
        }

        last.right = head.right;
        head.right.left = last;
        
        return head.right;
    }
}

public class Node
{
    public int val;
    public Node left;
    public Node right;

    public Node()
    {
    }

    public Node(int _val)
    {
        val = _val;
        left = null;
        right = null;
    }

    public Node(int _val, Node _left, Node _right)
    {
        val = _val;
        left = _left;
        right = _right;
    }
}