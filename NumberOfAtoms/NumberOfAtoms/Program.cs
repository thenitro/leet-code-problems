using System;
using System.Collections.Generic;
using System.Text;

namespace NumberOfAtoms
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("H2O" == new Solution().CountOfAtoms("H2O"));
            Console.WriteLine("H2MgO2" == new Solution().CountOfAtoms("Mg(OH)2"));
            Console.WriteLine("K4N2O14S4" == new Solution().CountOfAtoms("K4(ON(SO3)2)2"));
        }
    }
}

public class Solution
{
    public string CountOfAtoms(string formula)
    {
        var amounts = new Stack<int>();
        var results = new SortedDictionary<string, int>();
        
        var m = 1;

        for (var index = 0; index < formula.Length; index++)
        {
            var count = 0;

            if (formula[index] == '(')
            {
                var n = 1;

                while (n != 0 && index + count + 1 < formula.Length)
                {
                    switch (formula[index + count + 1])
                    {
                        case ')':
                            n--;
                            break;
                        case '(':
                            n++;
                            break;
                    }

                    count++;
                }

                var ti = index + count + 1;
                count = 0;

                while (ti + count < formula.Length && Char.IsDigit(formula, ti + count))
                {
                    count++;
                }

                var amount = count > 0 ? int.Parse(formula.Substring(ti, count)) : 1;
                amounts.Push(amount);

                m *= amount;
            }

            if (formula[index] == ')')
            {
                m /= amounts.Pop();

                while (index < formula.Length && Char.IsDigit(formula, index))
                {
                    index++;
                }

                continue;
            }

            if (!Char.IsUpper(formula[index])) continue;

            count = 0;
            
            while (index + count + 1 < formula.Length && Char.IsLower(formula, index + count + 1))
            {
                count++;
            }

            var element = formula.Substring(index, count + 1);
            index += count;

            count = 0;
            if (!results.ContainsKey(element))
            {
                results[element] = 0;
            }

            while (index + count + 1 < formula.Length && Char.IsDigit(formula, index + count + 1))
            {
                count++;
            }

            results[element] += m * (count == 0 ? 1 : int.Parse(formula.Substring(index + 1, count)));
            index += count;
        }

        var sb = new StringBuilder(results.Count * 2);
        foreach (var kv in results)
        {
            sb.Append(kv.Value > 1 ? $"{kv.Key}{kv.Value}" : $"{kv.Key}");
        }

        Console.WriteLine(sb.ToString());

        return sb.ToString();
    }
}