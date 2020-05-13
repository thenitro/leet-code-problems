using System;
using System.Collections.Generic;

namespace CanMakePalindromeFromSubstring
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //true, false, false, true, true
            Console.WriteLine(string.Join(",", new Solution().CanMakePaliQueries(
                "abcda", 
                new []
                {
                    new []{3, 3, 0},
                    new []{1, 2, 0},
                    new []{0, 3, 1},
                    new []{0, 3, 2},
                    new []{0, 4, 1},
                })));
            
            //false, true
            Console.WriteLine(string.Join(",", new Solution().CanMakePaliQueries(
                "lyb", 
                new []
                {
                    new []{0, 1, 0},
                    new []{2, 2, 1},
                })));
            
            //[false,true,true,true,false,true,true,true]
            Console.WriteLine(string.Join(",", new Solution().CanMakePaliQueries(
                "rkzavgdmdgt", 
                new []
                {
                    new int[] {5,8,0},
                    new int[] {7,9,1},
                    new int[] {3,6,4},
                    new int[] {5,5,1},
                    new int[] {8,10,0},
                    new int[] {3,9,5},
                    new int[] {0,10,10},
                    new int[] {6,8,3}
                })));
        }
    }
}

public class Solution
{
    public IList<bool> CanMakePaliQueries(string s, int[][] queries)
    {
        var result = new List<bool>();

        var count = new int[s.Length + 1][];
            count[0] = new int[26];

        for (var i = 0; i < s.Length; i++)
        {
            var prevCopy = new int[26];
            Array.Copy(count[i], prevCopy, 26);
            
            count[i + 1] = prevCopy;
            count[i + 1][s[i] - 'a']++;
        }

        foreach (var query in queries)
        {
            var sum = 0;

            for (var i = 0; i < 26; i++)
            {
                sum += (count[query[1] + 1][i] - count[query[0]][i]) % 2;
            }
            
            result.Add(sum / 2 <= query[2]);
        }
        
        return result;
    }
}