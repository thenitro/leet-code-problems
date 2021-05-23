using System;
using System.Collections.Generic;

namespace RestoreIpAddresses
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(string.Join(",", new Solution().RestoreIpAddresses("25525511135")));
            Console.WriteLine();
            Console.WriteLine(string.Join(",", new Solution().RestoreIpAddresses("0000")));
            Console.WriteLine();
            Console.WriteLine(string.Join(",", new Solution().RestoreIpAddresses("1111")));
            Console.WriteLine();
            Console.WriteLine(string.Join(",", new Solution().RestoreIpAddresses("010010")));
            Console.WriteLine();
            Console.WriteLine(string.Join(",", new Solution().RestoreIpAddresses("101023")));
            Console.WriteLine();
        }
    }

    public class Solution
    {
        public IList<string> RestoreIpAddresses(string s)
        {
            var result = new List<string>();

            for (var l1 = 1; l1 <= 3 && l1 < s.Length; l1++)
            {
                for (var l2 = 1; l2 <= 3 && l1 + l2 < s.Length; l2++)
                {
                    for (var l3 = 1; l3 <= 3 && l1 + l2 + l3 < s.Length; l3++)
                    {
                        var part1 = s.Substring(0, l1);
                        if (!CheckPart(part1))
                        {
                            continue;
                        }
                        
                        var part2 = s.Substring(l1, l2);
                        if (!CheckPart(part2))
                        {
                            continue;
                        }
                        
                        var part3 = s.Substring(l1 + l2, l3);
                        if (!CheckPart(part3))
                        {
                            continue;
                        }
                        
                        var leftover = s.Substring(l1 + l2 + l3);
                        if (!CheckPart(leftover))
                        {
                            continue;
                        }

                        result.Add(part1 + "." + part2 + "." + part3 + "." + leftover);
                    }
                }
            }
            
            return result;
        }

        private bool CheckPart(string part)
        {
            if (part.Length > 3)
            {
                return false;
            }

            if (part.Length > 1 && part[0] == '0')
            {
                return false;
            }

            if (int.Parse(part) > 255)
            {
                return false;
            }

            return true;
        }
    }
}