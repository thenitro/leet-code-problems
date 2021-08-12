using System.Collections.Generic;

namespace GroupShiftedStrings
{
    internal class Program
    {
        public static void Main(string[] args)
        {
        }
    }
}

public class Solution
{
    public IList<IList<string>> GroupStrings(string[] strings)
    {
        var dict = new Dictionary<string, List<string>>();
        var result = new List<IList<string>>();

        for (var i = 0; i < strings.Length; i++)
        {
            var word = strings[i];
            var length = word.Length;
            var t = length.ToString();

            for (var j = 1; j < length; j++)
            {
                var diff = (((word[j] - '0') - (word[j - 1] - '0')) + 26) % 26;
                t += diff.ToString();
            }

            var list = dict.ContainsKey(t) ? dict[t] : new List<string>();
                list.Add(word);

            dict[t] = list;
        }

        foreach (var value in dict.Values)
        {
            result.Add(value);
        }

        return result;
    }
}