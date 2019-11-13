using System;

namespace StudentAttendanceRecord1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(true == new Solution().CheckRecord("PPALLP"));
            Console.WriteLine(false == new Solution().CheckRecord("PPALLL"));
            Console.WriteLine(true == new Solution().CheckRecord("LLAPPP"));
            Console.WriteLine(false == new Solution().CheckRecord("LLLAPP"));
            Console.WriteLine(false == new Solution().CheckRecord("LLAPPA"));
        }
    }
}

public class Solution {
    public bool CheckRecord(string s)
    {
        var amountOfAs = 0;
        var amountOfContinuosL = 0;
        
        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] == 'A')
            {
                amountOfAs++;

                if (amountOfAs > 1)
                {
                    return false;
                }
            }

            if (s[i] == 'L')
            {
                amountOfContinuosL++;

                if (amountOfContinuosL > 2)
                {
                    return false;
                }
            } 
            else
            {
                amountOfContinuosL = 0;
            }
        }

        return true;
    }
}