using System;
using System.Text;

public class Solution
{
    public string GcdOfStrings(string str1, string str2)
    {
        var minString = str1.Length > str2.Length ? str2 : str1;
        var maxString = str1.Length > str2.Length ? str1 : str2;

        var gcd = new StringBuilder();
        gcd.Append(minString);

        return SolutionHelper(maxString, minString, gcd);
    }

    private string SolutionHelper(string max, string min, StringBuilder gcd)
    {
        if (gcd.Length == 0)
        {
            return string.Empty;
        }
        
        var newString = gcd.ToString();
        var newConstruct = string.Empty;
        var wasEqualsToMin = false;

        while (newConstruct.Length < max.Length)
        {
            newConstruct += newString;
            wasEqualsToMin = wasEqualsToMin || newConstruct == min;
        }

        if (wasEqualsToMin && newConstruct == max)
        {
            return newString;
        }

        gcd.Remove(gcd.Length - 1, 1);
        
        return SolutionHelper(max, min, gcd);
    }
}