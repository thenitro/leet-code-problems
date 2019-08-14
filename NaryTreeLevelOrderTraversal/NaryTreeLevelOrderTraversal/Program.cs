using System;
using System.Collections.Generic;

namespace NaryTreeLevelOrderTraversal
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var tree = new Node()
            {
                val = 1,
                children = new List<Node>()
                {
                    new Node()
                    {
                        val = 3,
                        children = new List<Node>()
                        {
                            new Node()
                            {
                                val = 5,
                            },
                            new Node()
                            {
                                val = 6,
                            },
                        }
                    },
                    new Node()
                    {
                        val = 2,
                    },
                    new Node()
                    {
                        val = 4,
                    },
                }
            };

            var result = new Solution().LevelOrder(tree);

            foreach (var i in result)
            {
                Console.WriteLine(string.Join(" ", i));
            }

            new Solution().LevelOrder(null);
        }
    }

    public class Node
    {
        public int val;
        public IList<Node> children;

        public Node()
        {
        }

        public Node(int _val, IList<Node> _children)
        {
            val = _val;
            children = _children;
        }
    }

    public class Solution 
    {
        public IList<IList<int>> LevelOrder(Node root)
        {
            var result = new List<IList<int>>();

            if (root == null)
            {
                return result;
            }
            
            var queue = new Queue<Node>();
                queue.Enqueue(root);

            var nextMax = 0;
            var currMax = 1;
            var count = 0;
                
            var subresult = new List<int>();

            while (queue.Count > 0)
            {
                var curr = queue.Dequeue();
                subresult.Add(curr.val);

                if (curr.children != null)
                {
                    nextMax += curr.children.Count; 
                    
                    foreach (var child in curr.children)
                    {
                        queue.Enqueue(child);
                    }
                }
                
                count++;

                if (count >= currMax)
                {
                    result.Add(subresult);
                    subresult = new List<int>();
                    
                    count = 0;
                    currMax = nextMax;
                    nextMax = 0;
                }
            }
            
            return result;
        }
    }
}