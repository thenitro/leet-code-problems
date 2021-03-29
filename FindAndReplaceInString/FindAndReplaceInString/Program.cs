using System;
using System.Collections.Generic;
using System.Text;

namespace FindAndReplaceInString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("eeebffff" ==
                              new Solution().FindReplaceString("abcd", new[] {0, 2}, new[] {"a", "cd"},
                                  new[] {"eee", "ffff"}));
        }
    }
}

public class Solution
{
    public string FindReplaceString(string S, int[] indexes, string[] sources, string[] targets)
    {
        var N = S.Length;
        var match = new int[N];

        for (var i = 0; i < N; i++)
        {
            match[i] = -1;
        }

        var ix = 0;
        for (var i = 0; i < indexes.Length; i++)
        {
            ix = indexes[i];
            if (S.Substring(ix, sources[i].Length).Equals(sources[i]))
            {
                match[ix] = i;
            }
        }

        var result = new StringBuilder();
        ix = 0;
        
        while (ix < N)
        {
            if (match[ix] >= 0)
            {
                result.Append(targets[match[ix]]);
                ix += sources[match[ix]].Length;
            }
            else
            {
                result.Append(S[ix++]);
            }
        }

        return result.ToString();
    }
}