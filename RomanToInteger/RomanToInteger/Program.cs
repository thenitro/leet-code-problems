using System;

namespace RomanToInteger
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("III 3 {0}", new Solution().RomanToInt("III"));
            Console.WriteLine("IV 4 {0}", new Solution().RomanToInt("IV"));
            Console.WriteLine("IX 9 {0}", new Solution().RomanToInt("IX"));
            Console.WriteLine("LVIII 58 {0}", new Solution().RomanToInt("LVIII"));
            Console.WriteLine("MCMXCIV 1994 {0}", new Solution().RomanToInt("MCMXCIV"));
        }
    }
}

public class Solution
{
    public int RomanToInt(string s)
    {
        var result = 0;

        for (int i = 0; i < s.Length; i++)
        {
            var currentInt = 0;
            
            switch (s[i])
            {
                case 'I':
                {
                    if (GetNextSymbol(s, i) == 'V')
                    {
                        currentInt = 4;
                        i++;
                        break;
                    }
                    
                    if (GetNextSymbol(s, i) == 'X')
                    {
                        currentInt = 9;
                        i++;
                        break;
                    }

                    currentInt = 1;
                    break;
                }

                case 'V':
                {
                    currentInt = 5;
                    break;
                }

                case 'X':
                {
                    if (GetNextSymbol(s, i) == 'L')
                    {
                        currentInt = 40;
                        i++;
                        break;
                    }
                    
                    if (GetNextSymbol(s, i) == 'C')
                    {
                        currentInt = 90;
                        i++;
                        break;
                    }

                    currentInt = 10;
                    break;
                }

                case 'L':
                {
                    currentInt = 50;
                    break;
                }

                case 'C':
                {
                    if (GetNextSymbol(s, i) == 'D')
                    {
                        currentInt = 400;
                        i++;
                        break;
                    }

                    if (GetNextSymbol(s, i) == 'M')
                    {
                        currentInt = 900;
                        i++;
                        break;
                    }
                    
                    currentInt = 100;
                    break;
                }

                case 'D':
                {
                    currentInt = 500;
                    break;
                }

                case 'M':
                {
                    currentInt = 1000;
                    break;
                }
            }
            
            result += currentInt;
        }

        return result;
    }

    private char GetNextSymbol(string s, int i)
    {
        var nextIndex = i + 1;
        
        if (nextIndex >= s.Length)
        {
            return '0';
        }

        return s[nextIndex];
    }
    
}