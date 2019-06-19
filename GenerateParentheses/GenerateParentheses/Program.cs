using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateParentheses
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var result = new Solution().GenerateParenthesis(3);

            foreach (var i in result)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
            
            result = new Solution().GenerateParenthesis(4);
            
            foreach (var i in result)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
        }
    }
}

public class Solution {
    public IList<string> GenerateParenthesis(int n) {
        var result = new List<string>();

        if (n == 0)
        {
            result.Add(string.Empty);
        }
        else
        {
            for (var i = 0; i < n; i++)
            {
                foreach (var left in GenerateParenthesis(i))
                {
                    foreach (var right in GenerateParenthesis(n - 1 - i))
                    {
                        var sb = new StringBuilder();
                            sb.Append("(");
                            sb.Append(left);
                            sb.Append(")");
                            sb.Append(right);
                        
                        result.Add(sb.ToString());
                    }
                }
            }
        }
        
        return result;
    }
}