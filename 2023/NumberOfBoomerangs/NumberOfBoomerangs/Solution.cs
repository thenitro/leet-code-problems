using System.Collections.Generic;

public class Solution
{
    public int NumberOfBoomerangs(int[][] points)
    {
        var dict = new Dictionary<int, int>();
        var boomerangs = 0;
        
        foreach (var p1 in points)
        {
            foreach (var p2 in points)
            {
                var distance = (p1[0] - p2[0]) * (p1[0] - p2[0]) + (p1[1] - p2[1]) * (p1[1] - p2[1]);
                dict[distance] = dict.ContainsKey(distance) ? dict[distance] + 1 : 1;
            }

            foreach (var count in dict.Values)
            {
                boomerangs += count * (count - 1);
            }
            
            dict.Clear();
        }

        return boomerangs;
    }
}