using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Runtime.InteropServices;
using System.Xml.Serialization.Configuration;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var target = new TreeNode(5)
            {
                left = new TreeNode(6),
                right = new TreeNode(2)
                {
                    left = new TreeNode(7),
                    right = new TreeNode(4)
                }
            };

            var root = new TreeNode(3)
            {
                left = target,
                right = new TreeNode(1)
                {
                    left = new TreeNode(0),
                    right = new TreeNode(8),
                }
            };

            var result = new Solution().DistanceK(root, target, 2);

            foreach (var i in result)//7 4 1
            {
                Console.Write(i + " ");
            }
            
            Console.WriteLine();

            target = new TreeNode(2);

            root = new TreeNode(0)
            {
                left = new TreeNode(1)
                {
                    left = new TreeNode(3),
                    right = target,
                }
            };

            result = new Solution().DistanceK(root, target, 1);

            foreach (var i in result)//1
            {
                Console.Write(i + " ");
            }
            
            Console.WriteLine("------------");
            
            target = new TreeNode(3);

            root = new TreeNode(0)
            {
                left = new TreeNode(2),
                right = new TreeNode(1)
                {
                    left = target
                }
            };

            result = new Solution().DistanceK(root, target, 3);

            foreach (var i in result)//2
            {
                Console.Write(i + " ");
            }
            
            Console.WriteLine();
            
            target = new TreeNode(3);

            root = new TreeNode(0)
            {
                left = new TreeNode(2),
                right = new TreeNode(1)
                {
                    left = target
                }
            };

            result = new Solution().DistanceK(root, target, 0);

            foreach (var i in result)//3
            {
                Console.Write(i + " ");
            }
            
            Console.WriteLine();

            root = new TreeNode(0)
            {
                right = new TreeNode(1)
                {
                    right = new TreeNode(2)
                    {
                        right = new TreeNode(3)
                        {
                            right = new TreeNode(4)
                        }
                    }
                }
            };

            result = new Solution().DistanceK(root, root, 2);

            foreach (var i in result)//2
            {
                Console.Write(i + " ");
            }
            
            Console.WriteLine();
        }
    }
}

public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}

public class Solution
{
    private List<int> _result;
    private TreeNode _target;
    private int _k;
    
    public IList<int> DistanceK(TreeNode root, TreeNode target, int K)
    {
        _result = new List<int>();
        _target = target;
        _k = K;

        Dfs(root);

        return _result;
    }

    private int Dfs(TreeNode node)
    {
        if (node == null)
        {
            return -1;
        } 
        else if (node == _target)
        {
            SubtreeAdd(node, 0);
            return 1;
        }
        else
        {
            var L = Dfs(node.left);
            var R = Dfs(node.right);

            if (L != -1)
            {
                if (L == _k)
                {
                    _result.Add(node.val);
                }

                SubtreeAdd(node.right, L + 1);
                return L + 1;
            } 
            else if (R != -1)
            {
                if (R == _k)
                {
                    _result.Add(node.val);
                }

                SubtreeAdd(node.left, R + 1);
                return R + 1;
            }
            else
            {
                return -1;
            }
        }
    }

    private void SubtreeAdd(TreeNode node, int dist)
    {
        if (node == null)
        {
            return;
        }

        if (dist == _k)
        {
            _result.Add(node.val);
        }
        else
        {
            SubtreeAdd(node.left, dist + 1);
            SubtreeAdd(node.right, dist + 1);
        }
    }
}