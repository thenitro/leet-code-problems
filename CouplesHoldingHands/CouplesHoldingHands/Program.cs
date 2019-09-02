using System;
using System.Collections.Generic;

namespace CouplesHoldingHands
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(1 == new Solution().MinSwapsCouples(new[] {0, 2, 1, 3}));
            Console.WriteLine(0 == new Solution().MinSwapsCouples(new[] {3, 2, 0, 3}));
        }
    }
}

public class Solution
{
    public int MinSwapsCouples(int[] row)
    {
        var count = 0;

        for (var i = 0; i < row.Length; i += 2)
        {
            var firstPartner = row[i];
            var secondPartner = (firstPartner % 2 == 0) ? firstPartner + 1 : firstPartner - 1;
            
            if (secondPartner == row[i + 1])
            {
                continue;
            }

            for (var j = i + 1; j < row.Length; j++)
            {
                if (row[j] == secondPartner)
                {
                    Swap(row, i + 1, j);
                    count++;
                    break;
                }
            }
        }
        
        return count;
    }

    private void Swap(int[] row, int i, int j)
    {
        var tmp = row[i];
        row[i] = row[j];
        row[j] = tmp;
    }
}