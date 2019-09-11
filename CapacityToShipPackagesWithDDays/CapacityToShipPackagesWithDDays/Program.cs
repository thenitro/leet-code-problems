using System;
using System.Diagnostics.Eventing.Reader;
using System.Linq;

namespace CapacityToShipPackagesWithDDays
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(15 == new Solution().ShipWithinDays(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}, 5));
            Console.WriteLine(6 == new Solution().ShipWithinDays(new[] {3, 2, 2, 4, 1, 4}, 3));
            Console.WriteLine(3 == new Solution().ShipWithinDays(new[] {1, 2, 3, 1, 1}, 4));
            Console.WriteLine(160 == new Solution().ShipWithinDays(new[] {10,50,100,100,50,100,100,100}, 5));
        }
    }
}

public class Solution
{
    public int ShipWithinDays(int[] weights, int D)
    {
        var loadRequired = weights.Max();
        
        while (true)
        {
            var days = 1;
            var weightSum = 0;
            var canCarry = true;
            
            for (var weightIndex = 0; weightIndex < weights.Length; weightIndex++)
            {
                var currentWeight = weights[weightIndex];

                if (weightSum + currentWeight > loadRequired)
                {
                    days++;
                    weightSum = currentWeight;
                }
                else
                {
                    weightSum += currentWeight;
                }

                if (days > D)
                {
                    break;
                }
            }

            if (canCarry && days == D)
            {
                break;
            }
            
            if (days < D)
            {
                break;
            }
            
            loadRequired++;
        }

        return loadRequired;
    }
}