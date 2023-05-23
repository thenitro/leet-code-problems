using System;
using System.Collections.Generic;

public class Solution
{
    public IList<int> BusiestServers(int k, int[] arrival, int[] load)
    {
        var expired = new int[k];
        var count = new int[k];
        var max = 0;

        for (var i = 0; i < arrival.Length; i++)
        {
            var time = arrival[i];
            var length = load[i];
            var server = i % k;

            for (var j = 0; j < k; j++, server++)
            {
                if (server == k) server = 0;

                if (expired[server] <= time)
                {
                    count[server]++;
                    expired[server] = time + length;

                    max = Math.Max(max, count[server]);
                    
                    break;
                }
            }
        }

        var result = new List<int>();

        for (var i = 0; i < k; i++)
        {
            if (count[i] == max)
            {
                result.Add(i);
            }
        }

        return result;
    }
}