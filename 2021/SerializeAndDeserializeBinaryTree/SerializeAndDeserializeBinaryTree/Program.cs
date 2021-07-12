using System;
using System.Collections.Generic;

namespace SerializeAndDeserializeBinaryTree
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var result = new Codec().deserialize("1,2,3,null,null,4,5");
            PrintTree(result);
        }

        private static void PrintTree(TreeNode root)
        {
            var queue = new Queue<TreeNode>();
                queue.Enqueue(root);

            var count = 1;

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                count--;

                Console.Write(node.val + " ");

                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }

                if (count == 0)
                {
                    Console.WriteLine();
                    count = queue.Count;
                }
            }
        }
    }
}

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int x)
    {
        val = x;
    }
}

public class Codec
{
    // Encodes a tree to a single string.
    public string serialize(TreeNode root)
    {
        if (root == null)
        {
            return "null,";
        }

        return root.val + "," + serialize(root.left) + serialize(root.right);
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data)
    {
        var queue = new Queue<string>();

        var splitted = data.Split(',');

        foreach (var s in splitted)
        {
            queue.Enqueue(s);
        }

        return MakeTree(queue);
    }

    private TreeNode MakeTree(Queue<string> queue)
    {
        if (queue.Count == 0)
        {
            return null;
        }
        
        var s = queue.Dequeue();
        if (s == "null")
        {
            return null;
        }

        var root = new TreeNode(int.Parse(s));
            
            root.left = MakeTree(queue);
            root.right = MakeTree(queue);

        return root;
    }
}