using System;
using System.Collections.Generic;

namespace BinarySearchTreeIterator
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var root1 = new TreeNode(7)
            {
                left = new TreeNode(3),
                right = new TreeNode(15)
                {
                    left = new TreeNode(9),
                    right = new TreeNode(20),
                }
            };

            var iterator1 = new BSTIterator(root1);
            Console.WriteLine(3 == iterator1.Next());
            Console.WriteLine(7 == iterator1.Next());
            Console.WriteLine(iterator1.HasNext());
            Console.WriteLine(9 == iterator1.Next());
            Console.WriteLine(iterator1.HasNext());
            Console.WriteLine(15 == iterator1.Next());
            Console.WriteLine(iterator1.HasNext());
            Console.WriteLine(20 == iterator1.Next());
            Console.WriteLine(false == iterator1.HasNext());
        }
    }
}

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class BSTIterator
{
    private Stack<TreeNode> _stack;
    private TreeNode _current;
    
    public BSTIterator(TreeNode root)
    {
        _stack = new Stack<TreeNode>();
        _current = root;
    }

    public int Next()
    {
        while (_current != null)
        {
            _stack.Push(_current);
            _current = _current.left;
        }

        _current = _stack.Pop();

        var result = _current.val;

        _current = _current.right;

        return result;
    }

    public bool HasNext()
    {
        return _current != null || _stack.Count > 0;
    }
}