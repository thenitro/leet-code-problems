using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace BinaryWatch
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var result = new Solution().ReadBinaryWatch(1);
            Console.WriteLine(string.Join(" ", result));
            
            var result2 = new Solution().ReadBinaryWatch(2);
            Console.WriteLine(string.Join(" ", result2));
            
            var result4 = new Solution().ReadBinaryWatch(4);
            Console.WriteLine(string.Join(" ", result4));
        }
    }
}

public class Solution {
    public IList<string> ReadBinaryWatch(int num)
    {
        var combination = new int[10];
        
        for (var i = 0; i < num; i++)
        {
            combination[i] = 1;
        }
        
        var results = new List<string>();

        Dfs(combination, new List<int>(), results, new bool[combination.Length]);
        
        return results;
    }

    private string ConvertToTime(string binary)
    {
        var hours = Convert.ToInt32(binary.Substring(0, 4), 2);

        if (hours > 11)
        {
            return string.Empty;
        }

        var minutes = Convert.ToInt32(binary.Substring(4, binary.Length - 4), 2);
        if (minutes > 59)
        {
            return string.Empty;
        }
        
        return hours + ":" + minutes.ToString("00");
    }

    private void Dfs(int[] combination, List<int> temp, List<string> results, bool[] visited)
    {
        if (temp.Count == combination.Length)
        {
            var result = ConvertToTime(string.Join("", temp));
            if (string.IsNullOrEmpty(result))
            {
                return;
            }
            
            results.Add(result);
            return;
        }

        for (var i = 0; i < combination.Length; i++)
        {
            if (visited[i])
            {
                continue;
            }

            visited[i] = true;
            temp.Add(combination[i]);
            
            Dfs(combination, temp, results, visited);
            
            visited[i] = false;
            temp.RemoveAt(temp.Count - 1);

            while (i < combination.Length - 1 && combination[i] == combination[i + 1])
            {
                i++;
            }
        }
    }
}