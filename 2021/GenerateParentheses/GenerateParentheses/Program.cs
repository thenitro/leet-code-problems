using System;
using System.Collections.Generic;
using System.Text;

namespace GenerateParentheses
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(string.Join(",", new Solution().GenerateParenthesis(1)));
            Console.WriteLine(string.Join(",", new Solution().GenerateParenthesis(2)));
            Console.WriteLine(string.Join(",", new Solution().GenerateParenthesis(3)));
        }
    }

    public class Solution
    {
        public IList<string> GenerateParenthesis(int n)
        {
            var result = new List<string>();
            SolutionHelper(result, new StringBuilder(), 0, 0, n);
            return result;
        }

        private void SolutionHelper(List<string> result, StringBuilder current, int open, int closed, int max)
        {
            if (current.Length == max * 2)
            {
                result.Add(current.ToString());
                return;
            }

            if (open < max)
            {
                current.Append("(");
                SolutionHelper(result, current, open + 1, closed, max);
                current.Remove(current.Length - 1, 1);
            }

            if (closed < open)
            {
                current.Append(")");
                SolutionHelper(result, current, open, closed + 1, max);
                current.Remove(current.Length - 1, 1);
            }
        }
    }
}