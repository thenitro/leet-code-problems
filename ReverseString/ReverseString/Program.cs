using System;

namespace ReverseString
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var arr = new char[] {'h', 'e', 'l', 'l', 'o'};
            
            new Solution().ReverseString(arr);

            foreach (var c in arr)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine();
            
            arr = new char[] {'H', 'a', 'n', 'n', 'a', 'h'};
            
            new Solution().ReverseString(arr);
            
            foreach (var c in arr)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine();
            
            arr = new char[] {'H'};
            
            new Solution().ReverseString(arr);
            
            foreach (var c in arr)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine();
            
            arr = new char[] {'H', 'R'};
            
            new Solution().ReverseString(arr);
            
            foreach (var c in arr)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine();
            
            arr = new char[] {};
            
            new Solution().ReverseString(arr);
            
            foreach (var c in arr)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine();
        }
    }
}

public class Solution {
    public void ReverseString(char[] s)
    {
        if (s.Length == 0 || s.Length == 1)
        {
            return;
        }
        
        var middle = s.Length / 2;

        for (var i = 0; i < middle; i++)
        {
            var end = s.Length - (i + 1); 
            
            var tmp = s[i];
            s[i] = s[end];
            s[end] = tmp;
        }
    }
}