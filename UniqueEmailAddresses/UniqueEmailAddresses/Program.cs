using System;
using System.Collections.Generic;
using System.Text;

namespace UniqueEmailAddresses
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(2 == new Solution().NumUniqueEmails(new [] { "test.email+alex@leetcode.com","test.e.mail+bob.cathy@leetcode.com","testemail+david@lee.tcode.com" }));
        }
    }
}

public class Solution
{
    public int NumUniqueEmails(string[] emails)
    {
        var result = new HashSet<string>();

        foreach (var email in emails)
        {
            var splitted = email.Split('@');
            var left = splitted[0];
            var sb = new StringBuilder();

            for (var i = 0; i < left.Length; i++)
            {
                if (left[i] == '+')
                {
                    break;
                }
                
                if (left[i] == '.')
                {
                    continue;
                } 
                
                sb.Append(left[i]);
            }

            sb.Append('@');
            sb.Append(splitted[1]);

            result.Add(sb.ToString());
        }
        
        return result.Count;
    }
}