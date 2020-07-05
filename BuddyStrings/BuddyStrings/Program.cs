using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BuddyStrings
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(true == new Solution().BuddyStrings("ab", "ba"));
            Console.WriteLine(false == new Solution().BuddyStrings("ab", "ab"));
            Console.WriteLine(true == new Solution().BuddyStrings("aa", "aa"));
        }
    }
}

public class Solution
{
    public bool BuddyStrings(string A, string B)
    {
        if (A.Length != B.Length)
        {
            return false;
        }

        if (A.Equals(B))
        {
            var s = new HashSet<char>();

            foreach (var c in A)
            {
                if (!s.Contains(c))
                {
                    s.Add(c);                    
                }
            }

            return s.Count < A.Length;
        }
        
        
        var diff = new List<int>();

        for (var i = 0; i < A.Length; i++)
        {
            if (A[i] != B[i])
            {
                diff.Add(i);
            }
        }

        return diff.Count == 2 && A[diff[0]] == B[diff[1]] && A[diff[1]] == B[diff[0]];
    }
}