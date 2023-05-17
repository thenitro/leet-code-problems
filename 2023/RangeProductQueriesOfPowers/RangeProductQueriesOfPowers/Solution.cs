using System;
using System.Collections.Generic;

public class Solution
{
    private int mod = (int)Math.Pow(10, 9) + 7;

    public int[] ProductQueries(int n, int[][] queries)
    {
        var result = new int[queries.Length];
        var powers = new List<int>();
        var x = n;

        while (x > 0)
        {
            var highestPower = (int)(Math.Log(x) / Math.Log(2));
            var pow = (int)Math.Pow(2, highestPower);
            x -= pow;
            powers.Insert(0, pow);
        }

        for (var i = 0; i < queries.Length; i++)
        {
            var start = queries[i][0];
            var end = queries[i][1];
            var subresult = (double)1;
            
            for (var j = start; j <= end; j++)
            {
                subresult = (subresult * powers[j]) % mod;
            }

            result[i] = (int)subresult % mod;
        }

        return result;
    }
}