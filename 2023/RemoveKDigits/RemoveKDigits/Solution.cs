using System.Collections.Generic;
using System.Text;

public class Solution
{
    public string RemoveKdigits(string num, int k)
    {
        var length = num.Length;
        if (length == 0)
        {
            return "0";
        }

        var stack = new Stack<char>();
            stack.Push('0');
            
        var i = 0;

        while (i < num.Length)
        {
            while (k > 0 && stack.Count > 0 && stack.Peek() > num[i])
            {
                stack.Pop();
                k--;
            }
            
            stack.Push(num[i]);
            i++;
        }

        while (k > 0)
        {
            stack.Pop();
            k--;
        }

        var result = new StringBuilder();

        while (stack.Count > 0)
        {
            result.Insert(0, stack.Pop());
        }

        while (result.Length > 1 && result[0] == '0')
        {
            result.Remove(0, 1);
        }

        return result.ToString();
    }
}