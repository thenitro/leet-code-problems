using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;

namespace SerializeAndDeserializeBinaryTree
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var codec = new Codec();

            var tree = new TreeNode(1)
            {
                left = new TreeNode(2),
                right = new TreeNode(3)
                {
                    left = new TreeNode(4),
                    right = new TreeNode(5)
                }
            };

            Console.WriteLine(codec.serialize(tree));

            var str = "[1,2,3,null,null,4,5]";
            var head = codec.deserialize(str);
            
            Traverse(head);
            
            var str2 = "[]";
            var head2 = codec.deserialize(str2);
            
            Traverse(head2);
            
            var str3 = "[1]";
            var head3 = codec.deserialize(str3);
            
            Traverse(head3);
            
            var str4 = "[1,3,null,null,4]";
            var head4 = codec.deserialize(str4);
            
            Traverse(head4);
            
            var str5 = "[1,2,null,3,null,4,null,5]";
            var head5 = codec.deserialize(str5);
            
            Traverse(head5);
        }

        private static void Traverse(TreeNode node)
        {
            if (node == null)
            {
                return;
            }
            
            Console.WriteLine(node.val);
            
            Traverse(node.left);
            Traverse(node.right);
        }
    }
}

public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}

public class Codec {

    // Encodes a tree to a single string.
    public string serialize(TreeNode root)
    {
        if (root == null)
        {
            return "[]";
        }

        var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

        var currentCount = 1;
        
        var result = new StringBuilder("[");
            
        while (queue.Count > 0)
        {
            var hasAtLeastOneChild = false;
            var subResult = new StringBuilder();
            
            for (var i = 0; i < currentCount; i++)
            {
                if (queue.Count == 0)
                {
                    break;
                }
                
                var element = queue.Dequeue();
                
                if (element == null)
                {
                    subResult.Append("null,");
                }
                else
                {
                    subResult.Append(element.val + ",");
                    hasAtLeastOneChild = true;
                    
                    queue.Enqueue(element.left);
                    queue.Enqueue(element.right);
                }
            }

            if (hasAtLeastOneChild)
            {
                result.Append(subResult);
            }

            currentCount *= 2;
        }

        result[result.Length - 1] = ']';
        
        return result.ToString();
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data)
    {
        var treeRaw = data.Split(new char[] {',', ']', '['});
        var tree = new List<string>();

        foreach (var s in treeRaw)
        {
            if (!string.IsNullOrEmpty(s))
            {
                tree.Add(s);
            }
        }
        
        if (tree.Count == 0)
        {
            return null;
        }

        var root = new TreeNode(int.Parse(tree[0]));
        var parents = new Queue<TreeNode>();
            parents.Enqueue(root);
        
        var count = 1;
        var currentCounter = 1;

        while (count < tree.Count)
        {
            for (var i = 0; i < currentCounter; i++)
            {
                var parent = parents.Count > 0 ? parents.Dequeue() : null;
                
                if (parent != null)
                {
                    parent.left = GetNode(count, tree); 
                    parent.right = GetNode(count + 1, tree);

                    if (parent.left != null)
                    {
                        parents.Enqueue(parent.left);                        
                    }

                    if (parent.right != null)
                    {
                        parents.Enqueue(parent.right);
                    }
                }
                
                count += 2;
            }

            currentCounter *= 2;
        }
        
        return root;
    }

    private TreeNode GetNode(int count, List<string> tree)
    {
        if (count >= tree.Count)
        {
            return null;
        }

        if (tree[count] == "null")
        {
            return null;
        }
        
        return new TreeNode(int.Parse(tree[count]));
    }
}
