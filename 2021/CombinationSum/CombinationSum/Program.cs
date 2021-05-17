using System;
using System.Collections.Generic;
using System.Text;

namespace CombinationSum
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            PrintResult(new Solution().CombinationSum(new []{ 2, 3, 6, 7 }, 7));
            PrintResult(new Solution().CombinationSum(new []{ 2, 3, 5 }, 8));
        }

        private static void PrintResult(IList<IList<int>> input)
        {
            var sb = new StringBuilder();
            
            foreach (var subresult in input)
            {
                sb.AppendLine(string.Join(",", subresult));
            }

            Console.WriteLine(sb.ToString());
        }
    }

    public class Solution
    {
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var result = new List<IList<int>>();

            SolutionHelper(candidates, target, 0, new int[] { 0 }, new List<int>(), result);
            
            return result;
        }

        private void SolutionHelper(int[] candidates, int target, int current, int[] startIndex, List<int> subresult, IList<IList<int>> result)
        {
            if (current > target)
            {
                startIndex[0]++;
                return;
            }
            
            if (target == current)
            {
                result.Add(new List<int>(subresult));
                startIndex[0]++;
                return;
            }

            for (var i = startIndex[0]; i < candidates.Length; i++)
            {
                subresult.Add(candidates[i]);
                SolutionHelper(candidates, target, current + candidates[i], startIndex, subresult, result);
                subresult.RemoveAt(subresult.Count - 1);
                startIndex[0] = i + 1;
            }
        }
    }
}