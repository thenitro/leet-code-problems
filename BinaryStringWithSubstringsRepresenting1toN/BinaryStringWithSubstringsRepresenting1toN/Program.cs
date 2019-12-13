using System;

namespace BinaryStringWithSubstringsRepresenting1toN
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(true == new Solution().QueryString("0110", 3));
            Console.WriteLine(false == new Solution().QueryString("0110", 4));
        }
    }
}

public class Solution {
    public bool QueryString(string S, int N)
    {
        var result = true;
        
        for (var i = 1; i <= N; i++)
        {
            var binary = Convert.ToString(i, 2);
            
            if (!S.Contains(binary))
            {
                result = false;
                break;
            }
        }

        return result;
    }
}